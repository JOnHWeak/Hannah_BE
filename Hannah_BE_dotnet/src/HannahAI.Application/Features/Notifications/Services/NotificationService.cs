using HannahAI.Application.Common.Interfaces;
using HannahAI.Domain.Entities.System;
using HannahAI.Domain.Enums;

namespace HannahAI.Application.Features.Notifications.Services;

public class NotificationService : INotificationService
{
    private readonly IRepository<Notification> _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(IRepository<Notification> notificationRepository, IUnitOfWork unitOfWork)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task SendNotificationAsync(Guid userId, NotificationType type, string message, string? link = null)
    {
        var notification = new Notification
        {
            UserId = userId,
            Type = type,
            Message = message,
            Link = link,
            IsRead = false
        };

        await _notificationRepository.AddAsync(notification);
        await _unitOfWork.CommitAsync();
    }
}

