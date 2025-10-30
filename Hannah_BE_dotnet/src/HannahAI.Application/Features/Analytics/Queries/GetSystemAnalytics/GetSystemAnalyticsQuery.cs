using MediatR;

namespace HannahAI.Application.Features.Analytics.Queries.GetSystemAnalytics;

// Define a DTO for system-wide analytics
public class SystemAnalyticsDto
{
    public int TotalUsers { get; set; }
    public int ActiveUsersToday { get; set; }
    public int TotalDocuments { get; set; }
    public int TotalQuizAttempts { get; set; }
}

public class GetSystemAnalyticsQuery : IRequest<SystemAnalyticsDto>
{
}

