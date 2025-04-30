using Microsoft.EntityFrameworkCore;
using StoredProcedure.Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

public class MyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

