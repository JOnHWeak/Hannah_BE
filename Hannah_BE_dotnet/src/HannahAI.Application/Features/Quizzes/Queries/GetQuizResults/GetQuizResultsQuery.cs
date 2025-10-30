using HannahAI.Application.Features.Quizzes.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Queries.GetQuizResults;

public class GetQuizResultsQuery : IRequest<QuizAttemptDto?>
{
    public Guid AttemptId { get; set; }
}

