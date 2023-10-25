﻿using Microsoft.IdentityModel.Tokens;
using N62Home1.Constants;
using N62Home1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N62Home1.Services;

public class TokenGeneratorService
{
    public string SecretKey = "8E6225FC-6E84-4E50-805F-FB3B5B6138BE";

    public async ValueTask<string> GetToken(User user) =>
        await new ValueTask<string>(new JwtSecurityTokenHandler().WriteToken(GetJwtToken(user)));

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
            new(ClaimConstants.UserId, user.Id.ToString()),
            new(ClaimConstants.FirstName, user.FirstName),
            new(ClaimConstants.LastName, user.LastName)
        };
}