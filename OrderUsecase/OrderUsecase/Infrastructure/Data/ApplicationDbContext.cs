using Microsoft.EntityFrameworkCore;
using OrderUsecase.Application;
using OrderUsecase.Core.Entities;
using System.Collections.Generic;

namespace OrderUsecase.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Anjali"},
                new Customer { Id = 2, Name = "Harsh"},
                new Customer { Id = 3, Name = "Akansha" },
                new Customer { Id = 4, Name = "Kishan" }
            );
        }
    }
}