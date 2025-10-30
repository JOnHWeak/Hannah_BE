using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Faculty.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Faculty.Queries.GetKnowledgeGaps;

public class GetKnowledgeGapsQuery : PaginationRequest, IRequest<PaginatedList<KnowledgeGapDto>>
{
    public Guid SubjectId { get; set; }
}

