using HannahAI.Domain.Entities.Academic;
using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.Progress;

public class UserConceptMastery : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;

    public string Concept { get; set; } = null!; // e.g., "Dependency Injection"
    public double MasteryLevel { get; set; } // A score from 0.0 to 1.0
}
