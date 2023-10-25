using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N63Task1.Api.Models.Dtos;
using N63Task1.Api.Services;

namespace N63Task1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
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
