using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string ResumeLink { get; set; }
        public string DocumentLink { get; set; }

        // Relationships
        public ICollection<JobApplication> JobApplications { get; set; }
        public ICollection<CandidateSkill> CandidateSkills { get; set; } 
    }

}
