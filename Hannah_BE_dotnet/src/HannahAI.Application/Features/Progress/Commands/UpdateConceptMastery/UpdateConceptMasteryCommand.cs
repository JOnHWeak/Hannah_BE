using MediatR;

namespace HannahAI.Application.Features.Progress.Commands.UpdateConceptMastery;

public class UpdateConceptMasteryCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid SubjectId { get; set; }
    public string Concept { get; set; } = null!;
    public double NewMasteryLevel { get; set; }
}
