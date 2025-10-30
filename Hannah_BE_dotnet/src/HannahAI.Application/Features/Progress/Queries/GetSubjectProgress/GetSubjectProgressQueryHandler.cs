using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Progress.DTOs;
using HannahAI.Domain.Entities.Progress;
using MediatR;

namespace HannahAI.Application.Features.Progress.Queries.GetSubjectProgress;

public class GetSubjectProgressQueryHandler : IRequestHandler<GetSubjectProgressQuery, UserProgressDto?>
{
    private readonly IRepository<UserSubjectProgress> _progressRepository;
    private readonly IMapper _mapper;

    public GetSubjectProgressQueryHandler(IRepository<UserSubjectProgress> progressRepository, IMapper mapper)
    {
        _progressRepository = progressRepository;
        _mapper = mapper;
    }

    public async Task<UserProgressDto?> Handle(GetSubjectProgressQuery request, CancellationToken cancellationToken)
    {
        var progress = (await _progressRepository.FindAsync(p => p.UserId == request.UserId && p.SubjectId == request.SubjectId, cancellationToken)).FirstOrDefault();
        return _mapper.Map<UserProgressDto?>(progress);
    }
}
