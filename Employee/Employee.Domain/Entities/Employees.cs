using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entities
{
    public class Employees
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Phone_no { get; set; }
        public string? Email { get; set; }

        public int DepartmentId { get; set; }  
   
        public int RoleId { get; set; }
         }
}
