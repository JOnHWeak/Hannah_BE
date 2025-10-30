namespace HannahAI.Application.Features.Analytics.DTOs;

public class AnalyticsEventDto
{
    public Guid? UserId { get; set; }
    public string EventType { get; set; } = null!;
    public string? EventData { get; set; }
    public DateTime Timestamp { get; set; }
}
