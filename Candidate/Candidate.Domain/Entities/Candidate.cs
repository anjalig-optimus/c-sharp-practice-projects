using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public string DocumentLink { get; set; }
        public string ResumeLink { get; set; }

    }
}
