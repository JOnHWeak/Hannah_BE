using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Quizzes.DTOs;
using HannahAI.Domain.Entities.Studio;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Queries.GetQuizResults;

public class GetQuizResultsQueryHandler : IRequestHandler<GetQuizResultsQuery, QuizAttemptDto?>
{
    private readonly IRepository<QuizAttempt> _attemptRepository;
    private readonly IMapper _mapper;

    public GetQuizResultsQueryHandler(IRepository<QuizAttempt> attemptRepository, IMapper mapper)
    {
        _attemptRepository = attemptRepository;
        _mapper = mapper;
    }

    public async Task<QuizAttemptDto?> Handle(GetQuizResultsQuery request, CancellationToken cancellationToken)
    {
        var attempt = await _attemptRepository.GetByIdAsync(request.AttemptId, cancellationToken);
        // In a real app, you might want to include details about the answers given.
        return _mapper.Map<QuizAttemptDto?>(attempt);
    }
}
