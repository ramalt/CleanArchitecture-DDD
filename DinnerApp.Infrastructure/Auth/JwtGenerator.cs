using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DinnerApp.Application.Common.Interfaces.Auth;
using DinnerApp.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DinnerApp.Infrastructure.Auth;

public class JwtGenerator : IJwtGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(User user)
    {
        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

        Claim[] claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
        };

        var securityToken = new JwtSecurityToken(issuer: _jwtSettings.Issuer,
                                                audience: _jwtSettings.Audience,
                                                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpireMinute),
                                                claims: claims,
                                                signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
