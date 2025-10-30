using HannahAI.Domain.Entities.Users;

namespace HannahAI.Application.Features.Auth.Services;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}
