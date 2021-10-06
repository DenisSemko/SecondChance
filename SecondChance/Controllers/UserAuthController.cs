using BLL.Services.Abstract;
using CIL.Additionals;
using CIL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SecondChance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthService userService;

        public UserAuthController(IUserAuthService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel registerModel)
        {
            var authResponse = await userService.RegisterAsync(registerModel);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                AccessToken = authResponse.AccessToken,
                Username = authResponse.Username,
                UserRole = authResponse.UserRole
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel loginModel)
        {
            var authResponse = await userService.LoginAsync(loginModel);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                AccessToken = authResponse.AccessToken,
                Username = authResponse.Username,
                UserRole = authResponse.UserRole
            });
        }
    }
}
