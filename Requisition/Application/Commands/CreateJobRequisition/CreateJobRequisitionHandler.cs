 using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreateJobRequisition
{
    public class CreateJobRequisitionHandler : IRequestHandler<CreateJobRequisitionCommand, int>

    {
        private readonly IJobRequisitionRepository repo;
        public CreateJobRequisitionHandler(IJobRequisitionRepository repository)
        {
            repo = repository;
        }
        public async Task<int> Handle(CreateJobRequisitionCommand request , CancellationToken cancellationToken)
        {
            var jobRequisition = new JobRequisition
            {
                Remarks = request.Remarks,
                Description = request.Description,
                JobRequisitionStatusId = request.JobRequisitionStatusId
            };
            await repo.AddAsync(jobRequisition);
            return jobRequisition.Id;
        }
    }
}
