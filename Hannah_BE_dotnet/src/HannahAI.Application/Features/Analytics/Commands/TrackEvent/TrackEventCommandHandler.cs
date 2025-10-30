using HannahAI.Application.Common.Interfaces;
using HannahAI.Domain.Entities.Analytics;
using MediatR;

namespace HannahAI.Application.Features.Analytics.Commands.TrackEvent;

public class TrackEventCommandHandler : IRequestHandler<TrackEventCommand>
{
    private readonly IRepository<AnalyticsEvent> _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TrackEventCommandHandler(IRepository<AnalyticsEvent> eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TrackEventCommand request, CancellationToken cancellationToken)
    {
        var newEvent = new AnalyticsEvent
        {
            UserId = request.UserId,
            EventType = request.EventType,
            EventData = request.EventData,
            Timestamp = DateTime.UtcNow
        };

        await _eventRepository.AddAsync(newEvent, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return;
    }
}
