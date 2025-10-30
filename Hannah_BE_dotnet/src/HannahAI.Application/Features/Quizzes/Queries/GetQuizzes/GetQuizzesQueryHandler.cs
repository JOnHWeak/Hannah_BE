using AutoMapper;
using AutoMapper.QueryableExtensions;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Quizzes.DTOs;
using HannahAI.Domain.Entities.Studio;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Queries.GetQuizzes;

public class GetQuizzesQueryHandler : IRequestHandler<GetQuizzesQuery, PaginatedList<QuizDto>>
{
    private readonly IRepository<Quiz> _quizRepository;
    private readonly IMapper _mapper;

    public GetQuizzesQueryHandler(IRepository<Quiz> quizRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<QuizDto>> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
    {
        var quizzes = (await _quizRepository.GetAllAsync(cancellationToken)).AsQueryable();

        if (request.SubjectId.HasValue)
        {
            quizzes = quizzes.Where(q => q.SubjectId == request.SubjectId.Value);
        }

        var mappedQuizzes = quizzes.ProjectTo<QuizDto>(_mapper.ConfigurationProvider);

        return PaginatedList<QuizDto>.Create(mappedQuizzes, request.PageNumber, request.PageSize);
    }
}
