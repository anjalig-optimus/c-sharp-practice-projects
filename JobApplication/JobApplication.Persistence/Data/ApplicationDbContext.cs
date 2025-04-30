using JobApplicationService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationService.Persistence.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options) {
        }
        
       public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }  
        
        
    }
}
