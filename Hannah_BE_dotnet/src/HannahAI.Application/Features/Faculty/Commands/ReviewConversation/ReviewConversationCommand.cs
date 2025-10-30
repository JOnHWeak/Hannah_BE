using MediatR;

namespace HannahAI.Application.Features.Faculty.Commands.ReviewConversation;

public class ReviewConversationCommand : IRequest
{
    public Guid ConversationId { get; set; }
    public bool IsFlagged { get; set; }
    public string? ReviewNotes { get; set; }
}
