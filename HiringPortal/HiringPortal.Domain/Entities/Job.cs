using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int YearsOfExperience { get; set; }

        // Foreign Keys
        public int RequisitionId { get; set; }
        public int EmploymentTypeId { get; set; }
        public int JobStatusId { get; set; }
        public int CreatedBy { get; set; }

        // Navigation Properties
        public Requisition Requisition { get; set; }
        public EmployeeType EmploymentType { get; set; }
        public JobStatus JobStatus { get; set; }
        public Employee CreatedByEmployee { get; set; }
        public ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();
    }

}
