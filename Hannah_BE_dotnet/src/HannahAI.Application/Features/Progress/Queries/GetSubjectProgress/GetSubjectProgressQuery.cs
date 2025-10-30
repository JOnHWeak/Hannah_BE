using HannahAI.Application.Features.Progress.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Progress.Queries.GetSubjectProgress;

public class GetSubjectProgressQuery : IRequest<UserProgressDto?>
{
    public Guid UserId { get; set; }
    public Guid SubjectId { get; set; }
}

