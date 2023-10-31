using Microsoft.IdentityModel.Tokens;
using N64.Identity.Application.Common.Constants;
using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class TokenGeneratorService : ITokenGenerateService
{
    private string SecretKey = "77bc2c70-8521-44d2-bc1d-42a2b0f2a4ef";

    public string GetToken(User user) =>
        new JwtSecurityTokenHandler().WriteToken(GetJwtToken(user));

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(issuer: "FileExplorer.DesktopApp",
            audience: "FileExplorer.UserApp",
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials);
    }

    public List<Claim> GetClaims(User user) =>
        new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.EmailAddress),
            new Claim(ClaimConstants.UserId, user.Id.ToString()),
        };
}