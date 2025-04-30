using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "dneidwu324838";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=readerRoleId
                    Name="Reader"
                }
            };
        }
        }
}
