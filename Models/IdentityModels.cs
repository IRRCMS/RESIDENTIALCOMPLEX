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
    }

    public class IrrcmsDbContext : IdentityDbContext<ApplicationUser>
    {
        public IrrcmsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {            
        }
        public virtual DbSet<BuildingUnit> BuildingUnits { get; set; }
        public virtual IDbSet<Cost> Costs { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<ResidentsCar> ResidentsCars { get; set; }
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

            modelBuilder.Entity<Person>()
                .HasMany<BuildingUnit>(p => p.BuildingUnits)
                .WithMany(b => b.Owners)
                .Map(pb =>
                        {
                            pb.ToTable("Building_Owner");
                        });

            modelBuilder.Entity<Resident>()
               .HasRequired(r => r.Person)
               .WithOptional(p => p.Resident);

            modelBuilder.Entity<Resident>()
                .HasRequired<Person>(p => p.Person)
                .WithRequiredPrincipal(r => r.Resident);

        }
    }
}