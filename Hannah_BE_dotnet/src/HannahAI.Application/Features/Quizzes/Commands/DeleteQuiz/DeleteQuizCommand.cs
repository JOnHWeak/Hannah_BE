using MediatR;

namespace HannahAI.Application.Features.Quizzes.Commands.DeleteQuiz;

public class DeleteQuizCommand : IRequest
{
    public Guid QuizId { get; set; }
}
