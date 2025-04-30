using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateJobRequisition
{
    public class UpdateJobRequisitionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Remarks { get; set; }
        public string Description { get; set; }
        public int JobRequisitionStatusId { get; set; }
    }
}
