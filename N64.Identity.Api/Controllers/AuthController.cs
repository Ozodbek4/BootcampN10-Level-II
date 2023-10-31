using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Services;

namespace N64.Identity.Api.Controllers;

[Route("api/controller")]
[ApiController]
[Authorize]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) =>
        _authService = authService;

    [AllowAnonymous]
    [HttpPut("register")]
    public async ValueTask<IActionResult> RegisterAsync(RegisterDetails registerDetails) =>
        Ok(await _authService.RegisterAsync(registerDetails));

    [AllowAnonymous]
    [HttpPut("login")]
    public async ValueTask<IActionResult> LoginAsync(LoginDetails loginDetails) =>
        Ok(await _authService.LoginAsync(loginDetails));
}