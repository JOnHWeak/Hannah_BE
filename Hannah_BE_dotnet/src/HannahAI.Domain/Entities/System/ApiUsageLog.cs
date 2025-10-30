using HannahAI.Domain.Entities.Common;
using HannahAI.Domain.Entities.Users;

namespace HannahAI.Domain.Entities.System;

public class ApiUsageLog : BaseEntity
{
    public Guid? UserId { get; set; }
    public User? User { get; set; }

    public string IpAddress { get; set; } = null!;
    public string RequestPath { get; set; } = null!;
    public string HttpMethod { get; set; } = null!;
    public int StatusCode { get; set; }
    public long DurationMs { get; set; }
    public DateTime Timestamp { get; set; }
}
