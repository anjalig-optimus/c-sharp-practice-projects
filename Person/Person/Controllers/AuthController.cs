using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Person_json.DTO;
using Person_json.Repository;
using System.Security.AccessControl;

namespace Person_json.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        public AuthController(UserManager<IdentityUser> userManager , ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerrequestdto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerrequestdto.Username,
                Email = registerrequestdto.Username
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerrequestdto.Password);

            if (identityResult.Succeeded)
            {
                if (registerrequestdto.Roles != null && registerrequestdto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerrequestdto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User already registered. Please login !!");
                    }
                }
            }
            return BadRequest("Something wrong");
            
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginrequestdto)
        {
            var user = await userManager.FindByEmailAsync(loginrequestdto.Username);
            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginrequestdto.Password);
                if (checkPasswordResult)
                {
                   var roles= await userManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken,
                        };
                        return Ok(jwtToken);
                    }
                    
                    return Ok();
                }
            }
            return BadRequest("Username or password incorrect");
        }
    }
}