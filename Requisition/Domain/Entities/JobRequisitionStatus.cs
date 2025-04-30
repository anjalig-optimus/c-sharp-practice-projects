using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JobRequisitionStatus
    {
        public int JobRequisitionStatusId { get; set; }
        public string Name { get; set; }

        public List<JobRequisition> JobRequisition;
    }
}
