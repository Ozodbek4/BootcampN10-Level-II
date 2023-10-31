using Microsoft.IdentityModel.Tokens;
using N64_Identity.Application.Common.Identity.Services;
using N64_Identity.Domain.Entities;
using N64_Identity.Infrastructure.Common.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N64_Identity.Infrastructure.Common.Identity.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    public string SecretKey = "958003b4-db33-4321-a375-545e3c833782";

    public string GetToken(User user) =>
        new JwtSecurityTokenHandler().WriteToken(GetJwtToken(user));

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(issuer: "Todo.ServerApp",
            audience: "Todo.ClientApp",
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);
    }

    public List<Claim> GetClaims(User user) =>
        new List<Claim>()
        {
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimConstants.UserId, user.Id.ToString())
        };
}