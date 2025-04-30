using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        public OrderController(IOrderRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var result= await _repo.GetAllAsync();
            return Ok(result);
           
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await _repo.CreateAsync(order);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            await _repo.UpdateAsync(order);
            return Ok();
        }
    }
}
