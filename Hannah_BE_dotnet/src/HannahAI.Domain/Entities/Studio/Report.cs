using HannahAI.Domain.Entities.Academic;
using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.Studio;

public class Report : BaseEntity, IAuditableEntity
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string ReportType { get; set; } = null!; // e.g., "Progress", "Analytics"

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid? SubjectId { get; set; }
    public Subject? Subject { get; set; }
}
