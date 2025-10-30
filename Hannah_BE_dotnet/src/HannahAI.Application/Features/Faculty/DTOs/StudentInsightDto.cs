namespace HannahAI.Application.Features.Faculty.DTOs;

public class StudentInsightDto
{
    public Guid StudentId { get; set; }
    public string StudentName { get; set; } = null!;
    public List<string> CommonMisconceptions { get; set; } = new();
    public List<string> KnowledgeGaps { get; set; } = new();
    public double EngagementLevel { get; set; }
}
