using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.Analytics;

public class AnalyticsEvent : BaseEntity
{
    public Guid? UserId { get; set; }
    public User? User { get; set; }

    public string EventType { get; set; } = null!; // e.g., "Login", "QuizStart", "DocumentView"
    public string? EventData { get; set; } // JSON string for additional data
    public DateTime Timestamp { get; set; }
}
