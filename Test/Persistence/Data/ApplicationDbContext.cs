using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
              }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(o=> o.OrderItems)
                .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Item)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.ItemId);

        }
    }
}
