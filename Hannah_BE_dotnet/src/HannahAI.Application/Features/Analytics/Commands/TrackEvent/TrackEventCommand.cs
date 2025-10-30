using MediatR;

namespace HannahAI.Application.Features.Analytics.Commands.TrackEvent;

public class TrackEventCommand : IRequest
{
    public Guid? UserId { get; set; }
    public string EventType { get; set; } = null!;
    public string? EventData { get; set; }
}
