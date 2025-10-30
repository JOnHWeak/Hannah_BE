using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.Conversation;

public class ConversationMetadata : BaseEntity, IAuditableEntity
{
    public Guid ConversationId { get; set; } // This is the primary key in MongoDB
    public string Title { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public bool IsFlagged { get; set; }
    public string? Summary { get; set; }
}
