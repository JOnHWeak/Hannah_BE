using HannahAI.Application.Features.Quizzes.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Commands.SubmitQuizAttempt;

public class SubmitQuizAttemptCommand : IRequest<QuizAttemptDto>
{
    public Guid UserId { get; set; }
    public Guid QuizId { get; set; }
    public List<SubmittedAnswerDto> Answers { get; set; } = new();
}
