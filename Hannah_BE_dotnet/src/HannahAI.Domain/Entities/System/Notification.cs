using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;
using HannahAI.Domain.Enums;

namespace HannahAI.Domain.Entities.System;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public NotificationType Type { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
    public string? Link { get; set; }
}
