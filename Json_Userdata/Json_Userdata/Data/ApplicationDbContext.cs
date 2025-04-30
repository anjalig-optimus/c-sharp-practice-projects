using Json_Userdata.Entities;
using Microsoft.EntityFrameworkCore;

namespace Json_Userdata.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
