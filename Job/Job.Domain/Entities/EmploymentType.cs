using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Domain.Entities
{
    public class EmploymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
