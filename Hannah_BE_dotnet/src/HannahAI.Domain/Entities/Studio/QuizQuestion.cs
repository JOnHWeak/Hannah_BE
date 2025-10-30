using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Enums;

namespace HannahAI.Domain.Entities.Studio;

public class QuizQuestion : BaseEntity
{
    public string Text { get; set; } = null!;
    public QuestionType Type { get; set; }

    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;

    public ICollection<QuizAnswer> Answers { get; set; } = new List<QuizAnswer>();
}
