using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace PasswordHashing.Models

{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}