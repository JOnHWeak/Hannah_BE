using HannahAI.Domain.Enums;
using MediatR;

namespace HannahAI.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public UserRole? Role { get; set; }
    public bool? IsActive { get; set; }
}
