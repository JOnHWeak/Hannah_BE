using AutoMapper;
using AutoMapper.QueryableExtensions;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Quizzes.DTOs;
using HannahAI.Domain.Entities.Studio;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Queries.GetQuizAttempts;

public class GetQuizAttemptsQueryHandler : IRequestHandler<GetQuizAttemptsQuery, PaginatedList<QuizAttemptDto>>
{
    private readonly IRepository<QuizAttempt> _attemptRepository;
    private readonly IMapper _mapper;

    public GetQuizAttemptsQueryHandler(IRepository<QuizAttempt> attemptRepository, IMapper mapper)
    {
        _attemptRepository = attemptRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<QuizAttemptDto>> Handle(GetQuizAttemptsQuery request, CancellationToken cancellationToken)
    {
        var attempts = (await _attemptRepository.FindAsync(a => a.UserId == request.UserId, cancellationToken)).AsQueryable();

        if (request.QuizId.HasValue)
        {
            attempts = attempts.Where(a => a.QuizId == request.QuizId.Value);
        }

        var mappedAttempts = attempts.ProjectTo<QuizAttemptDto>(_mapper.ConfigurationProvider);

        return PaginatedList<QuizAttemptDto>.Create(mappedAttempts, request.PageNumber, request.PageSize);
    }
}
