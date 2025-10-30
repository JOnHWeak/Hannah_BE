using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.System;

public class AuditLog : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Action { get; set; } = null!; // e.g., "CreateUser", "DeleteSubject"
    public string EntityName { get; set; } = null!; // e.g., "User", "Subject"
    public Guid EntityId { get; set; }
    public string? Changes { get; set; } // JSON string of changes
    public DateTime Timestamp { get; set; }
}
