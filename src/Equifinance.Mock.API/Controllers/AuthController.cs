using Equifinance.Mock.API.DTO;
using Equifinance.Mock.Core.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace Equifinance.Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService registrationService)
        {
            _authenticationService = registrationService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUserAsync([FromBody] UserDto request)
        {
            try
            {
                UserDto registeredUser = await _authenticationService.RegisterUserAsync(request);
                return Ok(registeredUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> LoginUserAsync([FromBody] LoginDto loginDto)
        {
            LoginResponseDto user = await _authenticationService.LoginAsync(loginDto);
            if (user == null)
            {
                return BadRequest(new { message = "Invalid" });
            }
            LoginResponseDto loginResponse = new()
            {
                Id = user.Id,
                Email = user.Email,
                Token = user.Token,
            };
            return Ok(loginResponse);
        }
    }
}
