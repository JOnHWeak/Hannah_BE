using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Notifications.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Notifications.Queries.GetUserNotifications;

public class GetUserNotificationsQuery : PaginationRequest, IRequest<PaginatedList<NotificationDto>>
{
    public Guid UserId { get; set; }
}

