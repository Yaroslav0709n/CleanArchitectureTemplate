using System.Security.Claims;
using System.Text;
using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Token;
using CleanArchitecture.Application.Dtos.Tokens;
using CleanArchitecture.Application.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Infrastructure.Authentication;

internal sealed class TokenProvider : ITokenProvider
{
    private readonly JwtSettings _jwtSettings;
    private readonly IIdentityService _identityService;

    public TokenProvider(IOptions<JwtSettings> options, IIdentityService identityService)
    {
        _jwtSettings = options.Value;
        _identityService = identityService;
    }

    public async Task<string> Create(CreateTokenRequest request)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, request.UserEmail)
        };

        var permissions = await _identityService.GetPermissionsAsync(request.UserId);

        claims.AddRange(permissions.Select(x => new Claim(Claims.Permission, x)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            SigningCredentials = credentials,
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience
        };

        return new JsonWebTokenHandler().CreateToken(tokenDescriptor);
    }
}
