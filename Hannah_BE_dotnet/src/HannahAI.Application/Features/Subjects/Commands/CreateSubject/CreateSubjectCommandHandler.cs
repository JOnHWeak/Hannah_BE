using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Subjects.DTOs;
using HannahAI.Domain.Entities.Academic;
using MediatR;

namespace HannahAI.Application.Features.Subjects.Commands.CreateSubject;

public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, SubjectDto>
{
    private readonly IRepository<Subject> _subjectRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSubjectCommandHandler(IRepository<Subject> subjectRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SubjectDto> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = new Subject
        {
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            SemesterId = request.SemesterId
        };

        await _subjectRepository.AddAsync(subject, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<SubjectDto>(subject);
    }
}
