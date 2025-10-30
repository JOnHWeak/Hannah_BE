using MediatR;

namespace HannahAI.Application.Features.Analytics.Queries.GetStudentInsights;

// Define a DTO for student insights
public class StudentInsightDto
{
    public Guid StudentId { get; set; }
    public string StudentName { get; set; } = null!;
    public string? MostChallengingConcept { get; set; }
    public double EngagementScore { get; set; }
}

public class GetStudentInsightsQuery : IRequest<IEnumerable<StudentInsightDto>>
{
    public Guid SubjectId { get; set; }
}

