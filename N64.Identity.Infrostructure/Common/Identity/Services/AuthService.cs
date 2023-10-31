using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Domain.Entities;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGenerateService _tokenGenerateService;

    private static readonly List<User> _users = new List<User>();

    public AuthService(ITokenGenerateService tokenGenerateService) =>
        _tokenGenerateService = tokenGenerateService;

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var user = _users.FirstOrDefault(item => item.EmailAddress == loginDetails.EmailAddress);

        if (user == null)
            throw new ArgumentNullException("User is not exists");

        return new ValueTask<string>(_tokenGenerateService.GetToken(user));
    }

    public ValueTask<bool> RegisterAsync(RegisterDetails registerDetails)
    {
        _users.Add(new User
        {
            Id = Guid.NewGuid(),
            FirstName = registerDetails.FirstName,
            LastName = registerDetails.LastName,
            Age = registerDetails.Age,
            EmailAddress = registerDetails.EmailAddress,
            Password = registerDetails.Password,
        });

        return new ValueTask<bool>(true);
    }
}