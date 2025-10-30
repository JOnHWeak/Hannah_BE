using AutoMapper;
using AutoMapper.QueryableExtensions;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Subjects.DTOs;
using HannahAI.Domain.Entities.Academic;
using MediatR;

namespace HannahAI.Application.Features.Subjects.Queries.GetSubjectsBySemester;

public class GetSubjectsBySemesterQueryHandler : IRequestHandler<GetSubjectsBySemesterQuery, PaginatedList<SubjectDto>>
{
    private readonly IRepository<Subject> _subjectRepository;
    private readonly IMapper _mapper;

    public GetSubjectsBySemesterQueryHandler(IRepository<Subject> subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<SubjectDto>> Handle(GetSubjectsBySemesterQuery request, CancellationToken cancellationToken)
    {
        // This is a simplified implementation. A real implementation should use IQueryable from the repository.
        var subjects = (await _subjectRepository.FindAsync(s => s.SemesterId == request.SemesterId, cancellationToken)).AsQueryable();

        var mappedSubjects = subjects.ProjectTo<SubjectDto>(_mapper.ConfigurationProvider);

        return PaginatedList<SubjectDto>.Create(mappedSubjects, request.PageNumber, request.PageSize);
    }
}
