using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationships
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}
