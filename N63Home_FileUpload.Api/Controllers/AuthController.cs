using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N63Home_FileUpload.Api.Models.Dtos;
using N63Home_FileUpload.Api.Services;

namespace N63Home_FileUpload.Api.Controllers
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
        [AllowAnonymous]
        [HttpPost("registeration")]
        public async ValueTask<IActionResult> RegistrationAsync([FromBody] RegistrationDetails registrationDetails) =>
            Ok(await _authService.RegistrationAsync(registrationDetails));

        [AllowAnonymous]
        [HttpPost("login")]
        public async ValueTask<IActionResult> LoginAsync([FromBody] LoginDetails loginDetails) =>
            Ok(await _authService.LoginAsync(loginDetails));
    }
}
