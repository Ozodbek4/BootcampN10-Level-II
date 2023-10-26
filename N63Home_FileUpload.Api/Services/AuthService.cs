using N63Home_FileUpload.Api.Models.Dtos;
using N63Home_FileUpload.Api.Models.Entities;
using System.Security.Authentication;

namespace N63Home_FileUpload.Api.Services;

public class AuthService
{
    private readonly TokenGeneratorService _tokenGeneratorService;

    private static readonly List<User> _users = new();

    public AuthService(TokenGeneratorService tokenGeneratorService)
    {
        _tokenGeneratorService = tokenGeneratorService;
    }

    public ValueTask<bool> RegistrationAsync(RegistrationDetails registrationDetails)
    {
        _users.Add(new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            Password = registrationDetails.Password,
        });

        return new ValueTask<bool>(true);
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var getUser = _users.FirstOrDefault(item => item.EmailAddress == loginDetails.EmailAddress);

        if (getUser == null)
            throw new AuthenticationException("User is not exists");

        return new ValueTask<string>(_tokenGeneratorService.GetToken(getUser));
    }
}