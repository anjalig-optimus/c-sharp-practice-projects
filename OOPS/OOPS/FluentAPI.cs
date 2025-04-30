using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class FluentAPI
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Person entity
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.PersonId);  // Setting the primary key
                entity.Property(p => p.Name)
                      .IsRequired()  // Name is required
                      .HasMaxLength(100);  // Max length of 100 characters for Name
                entity.Property(p => p.Age)
                      .HasDefaultValue(18);  // Default value for Age is 18
            });

            // Configure Address entity
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.AddressId);  // Setting the primary key
                entity.Property(a => a.Street)
                      .IsRequired()
                      .HasMaxLength(200);  // Max length for Street
                entity.Property(a => a.City)
                      .HasMaxLength(100);  // Max length for City
            });

            // Define one-to-one relationship between Person and Address
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)  // A person has one address
                .WithOne()  // One address is associated with one person
                .HasForeignKey<Person>(p => p.PersonId);  // Foreign key in Person
        }
    }
}
