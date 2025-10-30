namespace HannahAI.Application.Features.Quizzes.DTOs;

public class QuizDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int TimeLimitMinutes { get; set; }
    public Guid SubjectId { get; set; }
    public List<QuizQuestionDto> Questions { get; set; } = new();
}
