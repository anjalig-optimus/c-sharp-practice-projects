using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortal.Domain.Entities
{
    public class Requisition
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }

        // Foreign Keys
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public int ReviewerId { get; set; }
        public int StatusId { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public Role Role { get; set; }
        public Employee Employee { get; set; }
        public Employee Reviewer { get; set; }
        public RequisitionStatus Status { get; set; }
    }

}
