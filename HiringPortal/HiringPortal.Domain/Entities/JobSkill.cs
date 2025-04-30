using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class JobSkill
    {
        public int JobId { get; set; }
        public int SkillId { get; set; }

        // Navigation Properties
        public Job Job { get; set; }
        public SkillSet SkillSet { get; set; }
    }

}
