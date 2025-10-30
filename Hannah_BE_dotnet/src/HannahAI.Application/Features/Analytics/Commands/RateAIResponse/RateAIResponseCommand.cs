using MediatR;

namespace HannahAI.Application.Features.Analytics.Commands.RateAIResponse;

public class RateAIResponseCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid ConversationId { get; set; }
    public string MessageId { get; set; } = null!;
    public int Rating { get; set; }
    public string? Comment { get; set; }
}
