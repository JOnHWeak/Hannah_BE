using HannahAI.Domain.Enums;

namespace HannahAI.Application.Features.Notifications.DTOs;

public class NotificationDto
{
    public Guid Id { get; set; }
    public NotificationType Type { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
    public string? Link { get; set; }
    public DateTime CreatedAt { get; set; }
}
