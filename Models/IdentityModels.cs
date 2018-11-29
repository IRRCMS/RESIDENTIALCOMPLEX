using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Razor.Parser;
using IRRCMS.EntityModelsClasses;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IRRCMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<Resident> Residents { get; set; }

        public Person Person { get; set; }
    }

    public class IrrcmsDbContext : IdentityDbContext<ApplicationUser>
    {
        public IrrcmsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {            
        }
        public virtual IDbSet<BuildingUnit> BuildingUnits { get; set; }
        public virtual IDbSet<Cost> Costs { get; set; }
        public virtual IDbSet<Person> People { get; set; }
        public virtual IDbSet<Resident> Residents { get; set; }
        public virtual IDbSet<ResidentsCar> ResidentsCars { get; set; }

        public static IrrcmsDbContext Create()
        {
            return new IrrcmsDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .ToTable("Person");
            modelBuilder.Entity<BuildingUnit>()
                .ToTable("BuildingUnit");
            modelBuilder.Entity<ResidentsCar>()
                .ToTable("ResidentsCar");
            modelBuilder.Entity<Cost>()
                .ToTable("Cost");
            modelBuilder.Entity<Resident>()
                .ToTable("Resident");

            //User_Resident OneToMany Relationship.
            modelBuilder.Entity<Resident>()
                .HasRequired(r => r.User)
                .WithMany(a => a.Residents)
                .HasForeignKey(r => r.User_Id)
                .WillCascadeOnDelete();

            //Building_Resident OneToMany Relationship.
            modelBuilder.Entity<Resident>()
                .HasRequired(r => r.BuildingUnit)
                .WithMany(b => b.Residents)
                .HasForeignKey(r => r.BuildingUnit_Id);

            //Resident_Resident'sCar OneToMany Relationship.
            modelBuilder.Entity<ResidentsCar>()
                .HasRequired(r => r.Resident)
                .WithMany(r => r.ResidentsCars)
                .HasForeignKey(r => r.Resident_Id)
                .WillCascadeOnDelete();

            //Person_BuildingUnit ManyToMany Relationship.
            modelBuilder.Entity<Person>()
                .HasMany(p => p.BuildingUnits)                
                .WithMany(b => b.Owners)                
                .Map(pb =>
                {                    
                    pb.ToTable("Building_Owner");
                });

            //Person_ApplicationUser OneToZeroOrOne RelationShip.
            modelBuilder.Entity<Person>()
                .HasOptional(p => p.User)
                .WithOptionalDependent(u => u.Person);                
        }
    }
}