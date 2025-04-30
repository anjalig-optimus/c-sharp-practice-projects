using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class JobInterview
    {
        public int Id { get; set; }
        public DateTime Slot { get; set; }
        public string Remarks { get; set; }

        // Foreign Keys
        public int JobApplicationId { get; set; }
        public int InterviewStatusId { get; set; }
        public int StageId { get; set; }

        // Navigation Properties
        public JobApplication JobApplication { get; set; }
        public InterviewStatus InterviewStatus { get; set; }
        public Stage Stage { get; set; }
    }

}
