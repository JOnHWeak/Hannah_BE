using MediatR;

namespace HannahAI.Application.Features.Faculty.Commands.CreateCustomResponse;

public class CreateCustomResponseCommand : IRequest
{
    public Guid SubjectId { get; set; }
    public string TriggerPhrase { get; set; } = null!;
    public string ResponseText { get; set; } = null!;
}
