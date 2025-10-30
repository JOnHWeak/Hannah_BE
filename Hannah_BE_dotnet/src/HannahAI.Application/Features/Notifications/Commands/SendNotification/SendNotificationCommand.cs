using HannahAI.Domain.Enums;
using MediatR;

namespace HannahAI.Application.Features.Notifications.Commands.SendNotification;

public class SendNotificationCommand : IRequest
{
    public Guid UserId { get; set; }
    public NotificationType Type { get; set; }
    public string Message { get; set; } = null!;
    public string? Link { get; set; }
}
