using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobInterview.Domain.Entities
{
    public class InterviewStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<JobInterview> JobInterviews { get; set; }
    }
}
