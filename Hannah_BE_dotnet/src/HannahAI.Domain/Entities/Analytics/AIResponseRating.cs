using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.Analytics;

public class AIResponseRating : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid ConversationId { get; set; } // From MongoDB
    public string MessageId { get; set; } = null!; // From MongoDB

    public int Rating { get; set; } // e.g., 1-5
    public string? Comment { get; set; }
    public DateTime Timestamp { get; set; }
}
