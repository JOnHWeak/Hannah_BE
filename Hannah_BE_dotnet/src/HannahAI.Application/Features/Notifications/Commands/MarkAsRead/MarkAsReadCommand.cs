using MediatR;

namespace HannahAI.Application.Features.Notifications.Commands.MarkAsRead;

public class MarkAsReadCommand : IRequest
{
    public Guid NotificationId { get; set; }
    public Guid UserId { get; set; }
}
