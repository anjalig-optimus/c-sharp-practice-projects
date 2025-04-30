using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class CandidateSkill
    {
        public int CandidateId { get; set; }
        public int SkillId { get; set; }

        // Navigation Properties
        public Candidate Candidate { get; set;}
        public SkillSet SkillSet { get; set;}
    }

}
