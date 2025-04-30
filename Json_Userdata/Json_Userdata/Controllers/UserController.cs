using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Json_Userdata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        // Inject UserService into the controller
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET api/user/data?userId=1
        [HttpGet("data")]
        public async Task<IActionResult> GetUserData(int userId)
        {
            try
            {
                // Construct the dynamic JSON input
                var jsonInput = $"{{ \"userid\": {userId} }}";

                // Call the service method to execute the stored procedure with the dynamic JSON
                var result = await _userService.GetUserDataAsync(jsonInput);

                // Return the result from the stored procedure (assuming the result is JSON or plain text)
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle any errors
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPost("data")]
        public async Task<IActionResult> AddUserData([FromBody] dynamic userData)
        {
            try
            {
                // Construct the JSON input from the dynamic request body
                var jsonInput = JsonSerializer.Serialize(userData);

                // Call the service method to insert the data into the database
                await _userService.AddUserDataAsync(jsonInput);

                return Ok("User data inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
