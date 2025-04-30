using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        // Foreign Keys
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Properties
        public Role Role { get; set; }
        public Department Department { get; set; }
    }

}
