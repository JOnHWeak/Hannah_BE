using HannahAI.Application.Features.Progress.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Progress.Queries.GetUserProgress;

public class GetUserProgressQuery : IRequest<IEnumerable<UserProgressDto>>
{
    public Guid UserId { get; set; }
}

