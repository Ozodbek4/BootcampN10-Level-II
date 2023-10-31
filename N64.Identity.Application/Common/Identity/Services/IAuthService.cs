using N64.Identity.Application.Common.Identity.Models;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegisterDetails registerDetails);

    ValueTask<string> LoginAsync(LoginDetails loginDetails);
}