using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Quizzes.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Queries.GetQuizAttempts;

public class GetQuizAttemptsQuery : PaginationRequest, IRequest<PaginatedList<QuizAttemptDto>>
{
    public Guid UserId { get; set; }
    public Guid? QuizId { get; set; }
}

