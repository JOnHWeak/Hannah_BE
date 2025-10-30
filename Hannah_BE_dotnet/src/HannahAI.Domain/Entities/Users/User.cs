using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Enums;

namespace HannahAI.Domain.Entities.Users;

public class User : BaseEntity, IAuditableEntity
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public UserRole Role { get; set; }
    public bool IsActive { get; set; } = true;

    public Guid? UserProfileId { get; set; }
    public UserProfile? Profile { get; set; }

    public ICollection<UserSession> Sessions { get; set; } = new List<UserSession>();
}
