using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreateJobRequisition
{
    public class CreateJobRequisitionCommand : IRequest<int>
    {
        public string Remarks { get; set; }
        public string Description { get; set; }
        public int JobRequisitionStatusId { get; set; }
    }
}
