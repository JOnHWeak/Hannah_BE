using HannahAI.Domain.Entities.Academic;
using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Knowledge;

public class FAQ : BaseEntity, IAuditableEntity
{
    public string Question { get; set; } = null!;
    public string Answer { get; set; } = null!;

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;
}
