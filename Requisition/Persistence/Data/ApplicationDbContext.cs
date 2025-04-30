using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            
        }

        public DbSet<JobRequisition> JobRequisition { get; set; }
        public DbSet<JobRequisitionStatus> JobRequisitionStatus { get; set; }

        //public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        //{
        //    return await base.SaveChangesAsync(cancellationToken);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
             base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobRequisition>(entity =>
            {
                entity.HasKey(e =>e.Id);
                entity.Property(e => e.Remarks)
                 .IsRequired(false)
                 .HasMaxLength(500);
                entity.Property(e => e.Description)
                  .IsRequired(false)
                  .HasMaxLength(500);
                entity.HasOne(e => e.JobRequisitionStatus)
                .WithMany()
                .HasForeignKey(e => e.JobRequisitionStatusId);
            });

            modelBuilder.Entity<JobRequisitionStatus>(entity =>
            {  
                entity.HasKey(e => e.JobRequisitionStatusId);
                entity.Property(e => e.Name)
                 .HasMaxLength(500)
                 .IsRequired(false);
            });
        }
    }
}
