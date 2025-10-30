using MediatR;

namespace HannahAI.Application.Features.Auth.Commands.Logout;

public class LogoutCommand : IRequest
{
    public string RefreshToken { get; set; } = null!;
}
