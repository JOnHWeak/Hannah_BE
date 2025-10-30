using MediatR;

namespace HannahAI.Application.Features.Users.Commands.DeactivateUser;

public class DeactivateUserCommand : IRequest
{
    public Guid Id { get; set; }
}
