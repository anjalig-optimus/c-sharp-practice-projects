using Application.Commands.CreateJobRequisition;
using Application.Commands.DeleteJobRequisition;
using Application.Commands.UpdateJobRequisition;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequisitionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobRequisitionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, IJobRequisitionRepository repository)
        {
            var requisition = await repository.GetByIdAsync(id);
            if (requisition == null)
            {
                return NotFound();
            }
            return Ok(requisition);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobRequisitionCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id , UpdateJobRequisitionCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteJobRequisitionCommand { Id = id });
            return NoContent();
        } 
    }
}
