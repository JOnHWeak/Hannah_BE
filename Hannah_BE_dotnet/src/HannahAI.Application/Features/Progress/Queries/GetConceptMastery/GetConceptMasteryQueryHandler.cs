using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Progress.DTOs;
using HannahAI.Domain.Entities.Progress;
using MediatR;

namespace HannahAI.Application.Features.Progress.Queries.GetConceptMastery;

public class GetConceptMasteryQueryHandler : IRequestHandler<GetConceptMasteryQuery, IEnumerable<ConceptMasteryDto>>
{
    private readonly IRepository<UserConceptMastery> _masteryRepository;
    private readonly IMapper _mapper;

    public GetConceptMasteryQueryHandler(IRepository<UserConceptMastery> masteryRepository, IMapper mapper)
    {
        _masteryRepository = masteryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ConceptMasteryDto>> Handle(GetConceptMasteryQuery request, CancellationToken cancellationToken)
    {
        var mastery = await _masteryRepository.FindAsync(m => m.UserId == request.UserId && m.SubjectId == request.SubjectId, cancellationToken);
        return _mapper.Map<IEnumerable<ConceptMasteryDto>>(mastery);
    }
}
