using AutoMapper;
using AutoMapper.QueryableExtensions;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Notifications.DTOs;
using HannahAI.Domain.Entities.System;
using MediatR;

namespace HannahAI.Application.Features.Notifications.Queries.GetUserNotifications;

public class GetUserNotificationsQueryHandler : IRequestHandler<GetUserNotificationsQuery, PaginatedList<NotificationDto>>
{
    private readonly IRepository<Notification> _notificationRepository;
    private readonly IMapper _mapper;

    public GetUserNotificationsQueryHandler(IRepository<Notification> notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<NotificationDto>> Handle(GetUserNotificationsQuery request, CancellationToken cancellationToken)
    {
        var notifications = (await _notificationRepository.FindAsync(n => n.UserId == request.UserId, cancellationToken))
            .AsQueryable()
            .OrderByDescending(n => n.CreatedAt);

        var mappedNotifications = notifications.ProjectTo<NotificationDto>(_mapper.ConfigurationProvider);

        return PaginatedList<NotificationDto>.Create(mappedNotifications, request.PageNumber, request.PageSize);
    }
}
