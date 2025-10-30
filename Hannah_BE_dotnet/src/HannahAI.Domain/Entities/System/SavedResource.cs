using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.System;

public class SavedResource : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string ResourceType { get; set; } = null!; // e.g., "Document", "Quiz", "Conversation"
    public Guid ResourceId { get; set; }
    public string Title { get; set; } = null!;
    public string? Link { get; set; }
}
