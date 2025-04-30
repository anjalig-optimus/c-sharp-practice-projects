using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationships
        public ICollection<JobInterview> JobInterviews { get; set; } = new List<JobInterview>();
    }

}
