namespace HannahAI.Application.Features.Analytics.DTOs;

public class UserAnalyticsDto
{
    public Guid UserId { get; set; }
    public int LoginCount { get; set; }
    public TimeSpan TotalSessionTime { get; set; }
    public int QuizzesCompleted { get; set; }
    public double AverageQuizScore { get; set; }
}
