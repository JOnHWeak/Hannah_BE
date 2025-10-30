namespace HannahAI.Application.Features.Faculty.DTOs;

public class FlaggedConversationDto
{
    public Guid ConversationId { get; set; }
    public string Title { get; set; } = null!;
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public DateTime FlaggedAt { get; set; }
    public string? Reason { get; set; }
}
