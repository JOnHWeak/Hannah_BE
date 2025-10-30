using HannahAI.Domain.Entities.Academic;
using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Enums;

namespace HannahAI.Domain.Entities.Knowledge;

public class Document : BaseEntity, IAuditableEntity
{
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public long Size { get; set; }
    public ProcessingStatus Status { get; set; }

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;
}
