using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Progress.DTOs;
using HannahAI.Domain.Entities.Progress;
using MediatR;

namespace HannahAI.Application.Features.Progress.Queries.GetUserProgress;

public class GetUserProgressQueryHandler : IRequestHandler<GetUserProgressQuery, IEnumerable<UserProgressDto>>
{
    private readonly IRepository<UserSubjectProgress> _progressRepository;
    private readonly IMapper _mapper;

    public GetUserProgressQueryHandler(IRepository<UserSubjectProgress> progressRepository, IMapper mapper)
    {
        _progressRepository = progressRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserProgressDto>> Handle(GetUserProgressQuery request, CancellationToken cancellationToken)
    {
        var progress = await _progressRepository.FindAsync(p => p.UserId == request.UserId, cancellationToken);
        // This would require mapping from UserSubjectProgress to UserProgressDto, possibly including the Subject name.
        return _mapper.Map<IEnumerable<UserProgressDto>>(progress);
    }
}
