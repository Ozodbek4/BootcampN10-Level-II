using N63Task1.Api.Models.Dtos;
using N63Task1.Api.Models.Entities;
using System.Net;
using System.Security.Authentication;

namespace N63Task1.Api.Services;

public class AuthService
{
    private readonly TokenGeneratorService _tokenGeneratorService;

    private static readonly List<User> _users = new();

    public AuthService(TokenGeneratorService tokenGeneratorService)
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

        return  new(_tokenGeneratorService.GetToken(wantedUser!));
    }
}