using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.Studio;

public class QuizAttempt : BaseEntity, IAuditableEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;

    public int Score { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
