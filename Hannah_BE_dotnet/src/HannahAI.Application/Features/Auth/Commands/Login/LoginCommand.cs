using HannahAI.Application.Features.Auth.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
