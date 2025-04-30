using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeleteJobRequisition
{
    public class DeleteJobRequisitionHandler : IRequestHandler<DeleteJobRequisitionCommand , Unit>
    {
        private readonly IJobRequisitionRepository _repo;
        public DeleteJobRequisitionHandler(IJobRequisitionRepository repository)
        {
            _repo = repository;
        }
        public async Task<Unit> Handle(DeleteJobRequisitionCommand request, CancellationToken cancellationToken)
        {
            var jobRequisition = await _repo.GetByIdAsync(request.Id);
            if (jobRequisition == null) {
                throw new KeyNotFoundException("Not found");
            }
            await _repo.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
