using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobInterview.Domain.Entities
{
    public class JobInterview
    {
        public int Id { get; set; }      
      //  public int JobApplicationId { get; set; }
        public DateTime Slot {  get; set; }
        public int StageId { get; set; }
        public Stage Stage { get; set; }
        public int RemarksId { get; set; }
        public Remarks Remarks { get; set; }
        public int InterviewStatusId { get; set; }
        public InterviewStatus InterviewStatus { get; set; }

    }
}
