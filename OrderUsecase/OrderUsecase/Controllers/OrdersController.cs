using Microsoft.AspNetCore.Mvc;
using OrderUsecase.Application.Commands;
using OrderUsecase.Application.Queries;
using MediatR;

namespace OrderUsecase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController:ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            int a = 9;
            int b = 0;
            var c = a / b;
            if (command.CustomerId <= 0 || !command.OrderItems.Any())
            {
                return BadRequest("Invalid customer ID or empty order items.");
            }

            var orderId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { Id = id });

            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}
