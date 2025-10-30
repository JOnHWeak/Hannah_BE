using MediatR;

namespace HannahAI.Application.Features.Notifications.Queries.GetUnreadCount;

public class GetUnreadCountQuery : IRequest<int>
{
    public Guid UserId { get; set; }
}

