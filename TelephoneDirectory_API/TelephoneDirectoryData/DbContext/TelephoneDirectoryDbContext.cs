using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TelephoneDirectoryModel.Entity;
using Microsoft.AspNetCore.Identity;

namespace TelephoneDirectoryData.DbContext
{
    public class TelephoneDirectoryDbContext : IdentityDbContext<User>
    {
        public TelephoneDirectoryDbContext(DbContextOptions<TelephoneDirectoryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin"},
                new IdentityRole() { Name = "Regular", ConcurrencyStamp ="2,", NormalizedName = "Regular"}
                );
        }
    }
}
