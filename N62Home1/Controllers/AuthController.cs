using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N62Home1.Models;
using N62Home1.Services;

namespace N62Home1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenGeneratorService _tokenGeneratorService;

        public AuthController(TokenGeneratorService tokenGeneratorService)
        {
            _tokenGeneratorService = tokenGeneratorService;
        }

        [HttpPut]
        public async ValueTask<IActionResult> Login([FromBody] User user) =>
            Ok(await _tokenGeneratorService.GetToken(user));
    }
}