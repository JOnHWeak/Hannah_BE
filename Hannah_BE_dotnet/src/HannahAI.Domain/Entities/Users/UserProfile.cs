using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Enums;

namespace HannahAI.Domain.Entities.Users;

public class UserProfile : BaseEntity
{
    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }
    public string? StudentId { get; set; }
    public StudentSpecialty? Specialty { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}
