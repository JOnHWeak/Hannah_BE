using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Quizzes.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Queries.GetQuizzes;

public class GetQuizzesQuery : PaginationRequest, IRequest<PaginatedList<QuizDto>>
{
    public Guid? SubjectId { get; set; }
}

