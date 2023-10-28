using N65.Identity.Application.Common.Identity.Models;
using N65.Identity.Application.Common.Identity.Services;

namespace N65.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RegisterAsync(RegisterDetails registerDetails)
    {
        throw new NotImplementedException();
    }
}