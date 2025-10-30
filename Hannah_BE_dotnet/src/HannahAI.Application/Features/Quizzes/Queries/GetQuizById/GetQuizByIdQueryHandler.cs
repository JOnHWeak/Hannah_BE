using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Quizzes.DTOs;
using HannahAI.Domain.Entities.Studio;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Queries.GetQuizById;

public class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, QuizDto?>
{
    private readonly IRepository<Quiz> _quizRepository;
    private readonly IMapper _mapper;

    public GetQuizByIdQueryHandler(IRepository<Quiz> quizRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
    }

    public async Task<QuizDto?> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
    {
        // This would require the repository to support Include for Questions and Answers
        var quiz = await _quizRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<QuizDto?>(quiz);
    }
}
