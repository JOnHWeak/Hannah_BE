using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Users.DTOs;
using HannahAI.Domain.Entities.Users;
using MediatR;

namespace HannahAI.Application.Features.Users.Queries.GetUserProfile;

public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto?>
{
    private readonly IRepository<UserProfile> _profileRepository;
    private readonly IMapper _mapper;

    public GetUserProfileQueryHandler(IRepository<UserProfile> profileRepository, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }

    public async Task<UserProfileDto?> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var profile = (await _profileRepository.FindAsync(p => p.UserId == request.UserId, cancellationToken)).FirstOrDefault();
        return _mapper.Map<UserProfileDto?>(profile);
    }
}
