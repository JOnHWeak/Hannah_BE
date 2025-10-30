using HannahAI.Application.Features.Analytics.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Analytics.Queries.GetUserAnalytics;

public class GetUserAnalyticsQuery : IRequest<UserAnalyticsDto>
{
    public Guid UserId { get; set; }
}

