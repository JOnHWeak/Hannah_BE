namespace HannahAI.Application.Features.Admin.DTOs;

public class ApiUsageDto
{
    public string Endpoint { get; set; } = null!;
    public int RequestCount { get; set; }
    public double AverageResponseTimeMs { get; set; }
    public int ErrorCount { get; set; }
}
