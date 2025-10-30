using MediatR;

namespace HannahAI.Application.Features.Faculty.Commands.UpdateLearningOutcomes;

public class UpdateLearningOutcomesCommand : IRequest
{
    public Guid SubjectId { get; set; }
    public List<string> LearningOutcomes { get; set; } = new();
}
