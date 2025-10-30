using HannahAI.Domain.Entities.Academic;
using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.Progress;

public class UserSubjectProgress : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;

    public double ProgressPercentage { get; set; }
}
