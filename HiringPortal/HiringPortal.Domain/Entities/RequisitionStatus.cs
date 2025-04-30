using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class RequisitionStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationships
        public ICollection<Requisition> Requisitions { get; set; } = new List<Requisition>();
    }

}
