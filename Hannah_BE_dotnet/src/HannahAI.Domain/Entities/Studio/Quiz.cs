using HannahAI.Domain.Entities.Academic;
using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Studio;

public class Quiz : BaseEntity, IAuditableEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int TimeLimitMinutes { get; set; }

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;

    public ICollection<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
}
