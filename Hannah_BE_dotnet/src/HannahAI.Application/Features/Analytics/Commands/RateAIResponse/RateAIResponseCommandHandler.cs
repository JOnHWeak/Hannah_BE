using HannahAI.Application.Common.Interfaces;
using HannahAI.Domain.Entities.Analytics;
using MediatR;

namespace HannahAI.Application.Features.Analytics.Commands.RateAIResponse;

public class RateAIResponseCommandHandler : IRequestHandler<RateAIResponseCommand>
{
    private readonly IRepository<AIResponseRating> _ratingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RateAIResponseCommandHandler(IRepository<AIResponseRating> ratingRepository, IUnitOfWork unitOfWork)
    {
        _ratingRepository = ratingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RateAIResponseCommand request, CancellationToken cancellationToken)
    {
        var rating = new AIResponseRating
        {
            UserId = request.UserId,
            ConversationId = request.ConversationId,
            MessageId = request.MessageId,
            Rating = request.Rating,
            Comment = request.Comment,
            Timestamp = DateTime.UtcNow
        };

        await _ratingRepository.AddAsync(rating, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return;
    }
}
