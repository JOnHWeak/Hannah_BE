using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Studio;

public class Flashcard : BaseEntity
{
    public string FrontText { get; set; } = null!;
    public string BackText { get; set; } = null!;

    public Guid FlashcardSetId { get; set; }
    public FlashcardSet FlashcardSet { get; set; } = null!;
}
