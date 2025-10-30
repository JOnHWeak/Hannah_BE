namespace HannahAI.Application.Features.Admin.DTOs;

public class SystemHealthDto
{
    public string Status { get; set; } = null!;
    public string DatabaseStatus { get; set; } = null!;
    public string CacheStatus { get; set; } = null!;
    public long MemoryUsageBytes { get; set; }
}
