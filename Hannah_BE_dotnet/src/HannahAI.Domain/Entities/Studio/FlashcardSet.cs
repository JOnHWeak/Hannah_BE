using HannahAI.Domain.Entities.Academic;
using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Studio;

public class FlashcardSet : BaseEntity, IAuditableEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;

    public ICollection<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
}
