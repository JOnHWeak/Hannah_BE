using HannahAI.Application.Features.Quizzes.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Queries.GetQuizById;

public class GetQuizByIdQuery : IRequest<QuizDto?>
{
    public Guid Id { get; set; }
}
