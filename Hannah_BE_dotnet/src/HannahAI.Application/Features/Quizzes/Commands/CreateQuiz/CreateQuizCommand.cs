using HannahAI.Application.Features.Quizzes.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Commands.CreateQuiz;

public class CreateQuizCommand : IRequest<QuizDto>
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int TimeLimitMinutes { get; set; }
    public Guid SubjectId { get; set; }
    public List<CreateQuestionDto> Questions { get; set; } = new();
}

public class CreateQuestionDto
{
    public string Text { get; set; } = null!;
    public List<CreateAnswerDto> Answers { get; set; } = new();
}

public class CreateAnswerDto
{
    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; }
}
