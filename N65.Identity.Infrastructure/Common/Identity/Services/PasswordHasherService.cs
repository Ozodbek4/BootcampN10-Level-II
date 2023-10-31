using N65.Identity.Application.Common.Identity.Services;

namespace N65.Identity.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string PasswordHasher(string password)
    {
        throw new NotImplementedException();
    }

    public bool ValidatePassword(string password, string hashedPassword)
    {
        throw new NotImplementedException();
    }
}