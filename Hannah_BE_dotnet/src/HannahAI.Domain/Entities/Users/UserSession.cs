using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Users;

public class UserSession : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
}
