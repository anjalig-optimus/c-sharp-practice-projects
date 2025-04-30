using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        
        public int Age { get; set; }
        public List<Employees> Employees { get; set; }

    }
}
