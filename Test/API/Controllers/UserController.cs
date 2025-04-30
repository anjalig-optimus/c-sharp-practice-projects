using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            await _repo.AddAsync(user);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginRequest)
        {
            var user = _repo.ValidateUser(loginRequest.Username, loginRequest.Password);
            if (user != null)
            {
                return Ok(new { message = "Login successful", userId = user.Id, role = user.Role });
            }
            return Unauthorized("Invalid credentials");
        }
    }
}
