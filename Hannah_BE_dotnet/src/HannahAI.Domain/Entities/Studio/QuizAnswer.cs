using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Studio;

public class QuizAnswer : BaseEntity
{
    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; }

    public Guid QuestionId { get; set; }
    public QuizQuestion Question { get; set; } = null!;
}
