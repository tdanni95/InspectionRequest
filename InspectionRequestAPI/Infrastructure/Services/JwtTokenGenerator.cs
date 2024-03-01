using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InspectionRequestAPI.Common.Interfaces;
using InspectionRequestAPI.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InspectionRequestAPI.Infrastructure.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly JwtSettings jwtSettings;
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        this.dateTimeProvider = dateTimeProvider;
        this.jwtSettings = jwtOptions.Value;
    }
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(jwtSettings.Secret)),
   SecurityAlgorithms.HmacSha256);

        var role = "User";

        if (user.IsEngineer) role = "Engineer";
        else if (user.IsAdmin) role = "Admin";

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.ForName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.SurName),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
        Console.WriteLine(jwtSettings.ExpiryMinutes);
        var securityToken = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            expires: dateTimeProvider.Now.AddMinutes(jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
    public RefreshToken GenerateRefreshToken()
    {
        var token = new RefreshToken
        {
            Token = Guid.NewGuid().ToString(),
            Created = dateTimeProvider.Now,
            Expires = dateTimeProvider.Now.AddDays(7)
        };
        return token;
    }

}


public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Secret { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}

internal static class UserRoles
{
    public static readonly Dictionary<byte, string> Roles = new() {
            {1, "User" },
            {2, "Engineer"},
            {3, "Admin" }
        };
}