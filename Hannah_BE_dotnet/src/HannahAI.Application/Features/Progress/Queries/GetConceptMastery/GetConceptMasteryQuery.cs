using HannahAI.Application.Features.Progress.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Progress.Queries.GetConceptMastery;

public class GetConceptMasteryQuery : IRequest<IEnumerable<ConceptMasteryDto>>
{
    public Guid UserId { get; set; }
    public Guid SubjectId { get; set; }
}

