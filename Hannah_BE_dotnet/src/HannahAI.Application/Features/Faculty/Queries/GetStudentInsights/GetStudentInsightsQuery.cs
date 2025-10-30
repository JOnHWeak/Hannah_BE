using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Faculty.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Faculty.Queries.GetStudentInsights;

public class GetStudentInsightsQuery : PaginationRequest, IRequest<PaginatedList<StudentInsightDto>>
{
    public Guid SubjectId { get; set; }
}

