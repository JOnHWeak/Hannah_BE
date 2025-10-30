using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Users.DTOs;
using HannahAI.Domain.Entities.Users;
using MediatR;

namespace HannahAI.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<UserDto?>(user);
    }
}
