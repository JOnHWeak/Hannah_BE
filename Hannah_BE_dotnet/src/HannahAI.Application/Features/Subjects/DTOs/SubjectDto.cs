namespace HannahAI.Application.Features.Subjects.DTOs;

public class SubjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public Guid SemesterId { get; set; }
}
