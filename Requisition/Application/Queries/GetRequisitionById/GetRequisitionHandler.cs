using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetRequisitionById
{
    public class GetRequisitionHandler : IRequestHandler<GetRequisition, JobRequisition>
    {
        private readonly IJobRequisitionRepository repo;
        public GetRequisitionHandler(IJobRequisitionRepository repository)
        {
            repo = repository;
        }

        public async Task<JobRequisition> Handle(GetRequisition request, CancellationToken cancellationToken)
        {
            var jobRequisition = await repo.GetByIdAsync(request.Id);
            if (jobRequisition == null) {
                throw new KeyNotFoundException("Not found");
            }
            return jobRequisition;
        }
    }
}
