namespace HannahAI.Application.Features.Subjects.DTOs;

public class SemesterDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
