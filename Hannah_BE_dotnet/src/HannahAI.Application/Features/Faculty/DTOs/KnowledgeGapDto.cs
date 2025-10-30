namespace HannahAI.Application.Features.Faculty.DTOs;

public class KnowledgeGapDto
{
    public string Concept { get; set; } = null!;
    public int NumberOfStudentsStruggling { get; set; }
    public double AverageMasteryLevel { get; set; }
}
