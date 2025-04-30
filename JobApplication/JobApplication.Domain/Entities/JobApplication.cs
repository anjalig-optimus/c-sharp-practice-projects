using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationService.Domain.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int? CandidateId { get; set; }
        public int? ReferrerId { get; set; }
        public int StatusId { get; set; }
        public ApplicationStatus? Status { get; set; }
        public string? Remarks { get; set; }

    }
}
