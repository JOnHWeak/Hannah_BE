using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Studio;

public class MindMapCycle : BaseEntity
{
    public int CycleNumber { get; set; }
    public string? ContentJson { get; set; }
    public DateTime CompletedAt { get; set; }

    public Guid MindMapId { get; set; }
    public MindMap MindMap { get; set; } = null!;
}
