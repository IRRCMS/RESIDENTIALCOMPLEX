using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
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

        public static IrrcmsDbContext Create()
        {
            return new IrrcmsDbContext();
        }

        public DbSet<Person> People { get; set; }
        public DbSet<BuildingUnit> BuildingUnits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .ToTable("Person");
            modelBuilder.Entity<BuildingUnit>()
                .ToTable("BuildingUnit");
        }
    }
}