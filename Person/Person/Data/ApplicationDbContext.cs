using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Person_json.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Person_json.Data
{
    public class ApplicationDbContext :DbContext

    {
        public DbSet<Person> Persons { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
