using HannahAI.Application.Features.Users.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Admin.Commands.BulkCreateUsers;

public class BulkCreateUsersCommand : IRequest<IEnumerable<UserDto>>
{
    public List<CreateUserRequest> Users { get; set; } = new();
}
