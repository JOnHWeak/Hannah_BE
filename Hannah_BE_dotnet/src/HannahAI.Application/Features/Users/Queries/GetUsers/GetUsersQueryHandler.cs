using AutoMapper;
using AutoMapper.QueryableExtensions;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Users.DTOs;
using HannahAI.Domain.Entities.Users;
using MediatR;

namespace HannahAI.Application.Features.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PaginatedList<UserDto>>
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        // This is a simplified implementation. A real implementation should use IQueryable from the repository.
        var users = (await _userRepository.GetAllAsync(cancellationToken)).AsQueryable();

        // TODO: Add filtering based on request properties

        var mappedUsers = users.ProjectTo<UserDto>(_mapper.ConfigurationProvider);

        return PaginatedList<UserDto>.Create(mappedUsers, request.PageNumber, request.PageSize);
    }
}
