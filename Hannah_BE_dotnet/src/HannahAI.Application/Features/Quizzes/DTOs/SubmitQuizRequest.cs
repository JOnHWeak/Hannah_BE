namespace HannahAI.Application.Features.Quizzes.DTOs;

public class SubmitQuizRequest
{
    public Guid QuizId { get; set; }
    public List<SubmittedAnswerDto> Answers { get; set; } = new();
}

public class SubmittedAnswerDto
{
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
}
