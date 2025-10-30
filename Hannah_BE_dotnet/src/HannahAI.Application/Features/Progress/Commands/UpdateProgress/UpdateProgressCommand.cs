using MediatR;

namespace HannahAI.Application.Features.Progress.Commands.UpdateProgress;

public class UpdateProgressCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid SubjectId { get; set; }
    public double NewProgressPercentage { get; set; }
}
