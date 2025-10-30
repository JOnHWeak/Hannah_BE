namespace HannahAI.Application.Features.Progress.DTOs;

public class UserProgressDto
{
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; } = null!;
    public double ProgressPercentage { get; set; }
}
