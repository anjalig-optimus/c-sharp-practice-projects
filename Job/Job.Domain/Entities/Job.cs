using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int YOE { get; set; }
      //  public int RequisitionId { get; set; }
        public int EmploymentTypeId { get; set; }
        public EmploymentType EmploymentType { get; set; }

        public int JobStatusId { get; set; }
        public JobStatus JobStatus { get; set; }
    }
}
