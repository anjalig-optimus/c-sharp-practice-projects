using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class SkillSet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationships
        public ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();
        public ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();
    }

}
