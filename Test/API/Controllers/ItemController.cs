using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repo;
        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _repo.GetAllAsync();
            return Ok(items);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItem( Item item)
        {
            await _repo.AddAsync(item);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] Item item)
        {
            await _repo.UpdateAsync(item);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok();
        }
    }
}
