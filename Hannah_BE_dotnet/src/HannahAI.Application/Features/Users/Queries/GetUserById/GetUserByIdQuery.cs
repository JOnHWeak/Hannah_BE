using HannahAI.Application.Features.Users.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public Guid Id { get; set; }
}
