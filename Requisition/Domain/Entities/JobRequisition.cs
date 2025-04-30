using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JobRequisition
    {
        public int Id { get; set; }
        public string Remarks { get; set; }
        public string Description { get; set; }

        public int JobRequisitionStatusId { get; set; }

        public JobRequisitionStatus JobRequisitionStatus { get; set; }
    }
}
