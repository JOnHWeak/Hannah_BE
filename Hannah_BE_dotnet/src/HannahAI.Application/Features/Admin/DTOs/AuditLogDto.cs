namespace HannahAI.Application.Features.Admin.DTOs;

public class AuditLogDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Action { get; set; } = null!;
    public string EntityName { get; set; } = null!;
    public Guid EntityId { get; set; }
    public string? Changes { get; set; }
    public DateTime Timestamp { get; set; }
}
