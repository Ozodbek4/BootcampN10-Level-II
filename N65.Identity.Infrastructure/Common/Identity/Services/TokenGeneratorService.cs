using N65.Identity.Application.Common.Identity.Services;
using N65.Identity.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace N65.Identity.Infrastructure.Common.Identity.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    public List<Claim> GetClaims(User user)
    {
        throw new NotImplementedException();
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        throw new NotImplementedException();
    }

    public string GetToken(User user)
    {
        throw new NotImplementedException();
    }
}