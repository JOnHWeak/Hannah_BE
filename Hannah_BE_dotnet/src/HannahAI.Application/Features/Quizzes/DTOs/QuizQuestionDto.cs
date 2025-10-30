using HannahAI.Domain.Enums;

namespace HannahAI.Application.Features.Quizzes.DTOs;

public class QuizQuestionDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = null!;
    public QuestionType Type { get; set; }
    public List<QuizAnswerDto> Answers { get; set; } = new();
}

public class QuizAnswerDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = null!;
    // IsCorrect should not be exposed to the client when getting a quiz
}
