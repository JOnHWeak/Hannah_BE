using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Subjects.DTOs;
using HannahAI.Domain.Entities.Academic;
using MediatR;

namespace HannahAI.Application.Features.Subjects.Queries.GetSubjectById;

public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, SubjectDto?>
{
    private readonly IRepository<Subject> _subjectRepository;
    private readonly IMapper _mapper;

    public GetSubjectByIdQueryHandler(IRepository<Subject> subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    public async Task<SubjectDto?> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
    {
        var subject = await _subjectRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<SubjectDto?>(subject);
    }
}
