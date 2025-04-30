using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetRequisitionById
{
    public class GetRequisition : IRequest<JobRequisition>
    {
        public int Id { get; set; }
    }
}
