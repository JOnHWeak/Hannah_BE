using HannahAI.Application.Features.Users.DTOs;
using HannahAI.Domain.Enums;
using MediatR;

namespace HannahAI.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public UserRole Role { get; set; }
}
