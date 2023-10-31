using N65.Identity.Application.Common.Identity.Services;
using N65.Identity.Domain.Entities;

namespace N65.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    public ValueTask<User> CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> VerificationAsync(User user)
    {
        throw new NotImplementedException();
    }
}