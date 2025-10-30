using HannahAI.Domain.Enums;
using MediatR;

namespace HannahAI.Application.Features.Admin.Commands.ManageUserAccess;

public class ManageUserAccessCommand : IRequest
{
    public Guid UserId { get; set; }
    public UserRole NewRole { get; set; }
    public bool IsActive { get; set; }
}
