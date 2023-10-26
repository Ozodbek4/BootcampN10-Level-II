using Microsoft.IdentityModel.Tokens;
using N63Home_FileUpload.Api.Constants;
using N63Home_FileUpload.Api.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N63Home_FileUpload.Api.Services;

public class TokenGeneratorService
{
    private readonly string SecretKey = "b2ff8634-63ed-4a06-8051-be034d1c59c7";

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
        new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.EmailAddress),
            new Claim(ClaimConstants.UserId, user.Id.ToString()),
        };
}