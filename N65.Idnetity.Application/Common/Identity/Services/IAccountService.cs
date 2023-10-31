using N65.Identity.Domain.Entities;

namespace N65.Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<bool> VerificationAsync(User user);

    ValueTask<User> CreateUserAsync(User user);
}