using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N64_Identity.Application.Common.Identity.Models;
using N64_Identity.Application.Common.Identity.Services;

namespace N64_Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async ValueTask<IActionResult> Register(RegistrationDetails registrationDetails) =>
            Ok(await _authService.RegistenationAsync(registrationDetails));

        [HttpPost("login")]
        public async ValueTask<IActionResult> Login(LoginDetails loginDetails) =>
            Ok(await _authService.LoginAsync(loginDetails));
    }
}
