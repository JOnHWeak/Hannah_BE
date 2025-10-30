using HannahAI.Domain.Entities.Academic;
using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Studio;

public class MindMap : BaseEntity, IAuditableEntity
{
    public string Title { get; set; } = null!;
    public string? ContentJson { get; set; } // Store mind map data as JSON

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;

    public ICollection<MindMapCycle> Cycles { get; set; } = new List<MindMapCycle>();
}
