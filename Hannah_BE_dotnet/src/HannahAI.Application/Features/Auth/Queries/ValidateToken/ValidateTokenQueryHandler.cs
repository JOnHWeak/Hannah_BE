using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HannahAI.Application.Features.Auth.Queries.ValidateToken;

public class ValidateTokenQueryHandler : IRequestHandler<ValidateTokenQuery, bool>
{
    // In a real app, you'd get these from configuration
    private readonly string _jwtSecret = "a_very_long_and_secure_secret_key_that_is_at_least_32_bytes";
    private readonly string _issuer = "HannahAI.Api";
    private readonly string _audience = "HannahAI.Client";

    public Task<bool> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);

        try
        {
            tokenHandler.ValidateToken(request.AccessToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidAudience = _audience,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
}
