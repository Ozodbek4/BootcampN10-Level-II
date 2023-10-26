using N64_Identity.Application.Common.Identity.Models;
using System.Net;
using N64_Identity.Application.Common.Identity.Services;
using System.Security.Authentication;
using N64_Identity.Domain.Entities;

namespace N64_Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGeneratorService;

    private static readonly List<User> _users = new();

    public AuthService(ITokenGeneratorService tokenGeneratorService)
    {
        _tokenGeneratorService = tokenGeneratorService;
    }

    public ValueTask<bool> RegistenationAsync(RegistrationDetails registrationDetails)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            Password = registrationDetails.Password,
        };
        _users.Add(user);

        return new(true);
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var wantedUser = _users.FirstOrDefault(user => user.EmailAddress == loginDetails.EmailAddress && user.Password == loginDetails.Password);

        if (wantedUser is null)
            throw new AuthenticationException("User is not found");

        return new(_tokenGeneratorService.GetToken(wantedUser!));
    }
}