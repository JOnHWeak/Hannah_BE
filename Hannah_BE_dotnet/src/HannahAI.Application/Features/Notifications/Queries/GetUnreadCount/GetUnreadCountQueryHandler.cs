using HannahAI.Application.Common.Interfaces;
using HannahAI.Domain.Entities.System;
using MediatR;

namespace HannahAI.Application.Features.Notifications.Queries.GetUnreadCount;

public class GetUnreadCountQueryHandler : IRequestHandler<GetUnreadCountQuery, int>
{
    private readonly IRepository<Notification> _notificationRepository;

    public GetUnreadCountQueryHandler(IRepository<Notification> notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<int> Handle(GetUnreadCountQuery request, CancellationToken cancellationToken)
    {
        var unreadCount = (await _notificationRepository.FindAsync(n => n.UserId == request.UserId && !n.IsRead, cancellationToken)).Count();
        return unreadCount;
    }
}
