using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateJobRequisition
{
    public class UpdateJobRequisitionHandler : IRequestHandler<UpdateJobRequisitionCommand , Unit>
    {
        private readonly IJobRequisitionRepository repo;
        public UpdateJobRequisitionHandler(IJobRequisitionRepository repository) {
            repo= repository;
        }
        public async Task<Unit> Handle(UpdateJobRequisitionCommand request, CancellationToken cancellationToken)
        {
            var jobRequisition = await repo.GetByIdAsync(request.Id);
            if (jobRequisition == null)
            {
                throw new KeyNotFoundException("Not found");
            }
            jobRequisition.Remarks = request.Remarks;
            jobRequisition.Description = request.Description;
            jobRequisition.JobRequisitionStatusId = request.JobRequisitionStatusId;

            await repo.UpdateAsync(jobRequisition);
             return Unit.Value;
           // return true;
        }
    }
}
