using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Emit;
using HiringPortal.Domain.Entities;

namespace HiringPortal.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets for entities
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<RequisitionStatus> RequisitionStatuses {get; set;}
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobStatus> JobStatuses { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobApplication> JobApplications {get;set;}
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<JobInterview> JobInterviews { get; set; }
        public DbSet<InterviewStatus> InterviewStatuses { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Role Configuration
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(100);

                entity.HasMany(r => r.Employees)
                      .WithOne(e => e.Role)
                      .HasForeignKey(e => e.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);

                //RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required.");
               // RuleFor(c => c.Age).GreaterThan(18).WithMessage("You must be over 18.");
            });

            // Department Configuration
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Name).IsRequired().HasMaxLength(100);

                entity.HasMany(d => d.Employees)
                      .WithOne(e => e.Department)
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(d => d.Requisitions)
                      .WithOne(r => r.Department)
                      .HasForeignKey(r => r.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Employee Configuration
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.PhoneNo).HasMaxLength(15);
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.HasOne(e => e.Role)
                      .WithMany(r => r.Employees)
                      .HasForeignKey(e => e.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Department)
                      .WithMany(d => d.Employees)
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Requisition Configuration
            modelBuilder.Entity<Requisition>(entity =>
            {
                entity.HasKey(r => r.Id);
               

                entity.HasOne(r => r.Department)
                      .WithMany(d => d.Requisitions)
                      .HasForeignKey(r => r.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Role)
                      .WithMany()
                      .HasForeignKey(r => r.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Status)
                      .WithMany(rs => rs.Requisitions)
                      .HasForeignKey(r => r.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Reviewer)
                      .WithMany()
                      .HasForeignKey(r => r.ReviewerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Job Configuration
            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(j => j.Id);
                

                entity.HasOne(j => j.Requisition)
                      .WithMany()
                      .HasForeignKey(j => j.RequisitionId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(j => j.EmploymentType)
                      .WithMany(et => et.Jobs)
                      .HasForeignKey(j => j.EmploymentTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(j => j.JobStatus)
                      .WithMany(js => js.Jobs)
                      .HasForeignKey(j => j.JobStatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Candidate Configuration
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(150);
                entity.Property(c => c.PhoneNo).HasMaxLength(15);
                entity.Property(c => c.Email).HasMaxLength(100);
                entity.Property(c => c.ResumeLink).HasMaxLength(500);
                entity.Property(c => c.DocumentLink).HasMaxLength(500);
            });

            // Job Application Configuration
            modelBuilder.Entity<JobApplication>(entity =>
            {
                entity.HasKey(ja => ja.Id);

                entity.HasOne(ja => ja.Candidate)
                      .WithMany(c => c.JobApplications)
                      .HasForeignKey(ja => ja.CandidateId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ja => ja.Job)
                      .WithMany()
                      .HasForeignKey(ja => ja.JobId)
                      .OnDelete(DeleteBehavior.Restrict);

                //entity.HasOne(ja => ja.Status)
                //      .WithMany(as => as.JobApplications)
                //      .HasForeignKey(ja => ja.StatusId)
                //      .OnDelete(DeleteBehavior.Restrict);
            });

            // Job Interview Configuration
            modelBuilder.Entity<JobInterview>(entity =>
            {
                entity.HasKey(ji => ji.Id);

                entity.HasOne(ji => ji.JobApplication)
                      .WithMany()
                      .HasForeignKey(ji => ji.JobApplicationId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ji => ji.InterviewStatus)
                      .WithMany(i => i.JobInterviews)
                      .HasForeignKey(ji => ji.InterviewStatusId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ji => ji.Stage)
                      .WithMany(s => s.JobInterviews)
                      .HasForeignKey(ji => ji.StageId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Skill Set Configuration
            modelBuilder.Entity<SkillSet>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<JobSkill>(entity =>
            {
                entity.HasKey(js => new { js.JobId, js.SkillId });

                entity.HasOne(js => js.Job)
                      .WithMany(j => j.JobSkills)
                      .HasForeignKey(js => js.JobId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(js => js.SkillSet)
                      .WithMany(ss => ss.JobSkills)
                      .HasForeignKey(js => js.SkillId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CandidateSkill>(entity =>
            {
                entity.HasKey(cs => new { cs.CandidateId, cs.SkillId });

                entity.HasOne(cs => cs.Candidate)
                      .WithMany(c => c.CandidateSkills)
                      .HasForeignKey(cs => cs.CandidateId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(cs => cs.SkillSet)
                      .WithMany(ss => ss.CandidateSkills)
                      .HasForeignKey(cs => cs.SkillId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }


}

