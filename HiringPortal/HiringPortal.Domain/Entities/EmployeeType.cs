using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class EmployeeType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationships
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }

}
