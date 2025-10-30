using HannahAI.Application.Features.Analytics.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Analytics.Queries.GetSubjectAnalytics;

public class GetSubjectAnalyticsQuery : IRequest<SubjectAnalyticsDto>
{
    public Guid SubjectId { get; set; }
}

