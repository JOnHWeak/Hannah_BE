using HannahAI.Domain.Enums;

namespace HannahAI.Application.Features.Notifications.Services;

public interface INotificationService
{
    Task SendNotificationAsync(Guid userId, NotificationType type, string message, string? link = null);
}

