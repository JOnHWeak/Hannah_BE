using HannahAI.Application.Features.Auth.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<TokenResponse>
{
    public string RefreshToken { get; set; } = null!;
}
