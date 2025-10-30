using AutoMapper;
using AutoMapper.QueryableExtensions;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Subjects.DTOs;
using HannahAI.Domain.Entities.Academic;
using MediatR;

namespace HannahAI.Application.Features.Subjects.Queries.GetSubjects;

public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, PaginatedList<SubjectDto>>
{
    private readonly IRepository<Subject> _subjectRepository;
    private readonly IMapper _mapper;

    public GetSubjectsQueryHandler(IRepository<Subject> subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<SubjectDto>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
    {
        var subjects = (await _subjectRepository.GetAllAsync(cancellationToken)).AsQueryable();

        var mappedSubjects = subjects.ProjectTo<SubjectDto>(_mapper.ConfigurationProvider);

        return PaginatedList<SubjectDto>.Create(mappedSubjects, request.PageNumber, request.PageSize);
    }
}
