namespace HannahAI.Application.Features.Analytics.DTOs;

public class SubjectAnalyticsDto
{
    public Guid SubjectId { get; set; }
    public int TotalEnrollments { get; set; }
    public double AverageCompletionRate { get; set; }
    public double AverageScore { get; set; }
}
