using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Auth.Services;
using HannahAI.Application.Features.Users.DTOs;
using HannahAI.Domain.Entities.Users;
using MediatR;

namespace HannahAI.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IRepository<User> _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IRepository<User> userRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Check if user already exists
        var existingUser = (await _userRepository.FindAsync(u => u.Email == request.Email || u.Username == request.Username, cancellationToken)).FirstOrDefault();
        if (existingUser != null)
        {
            throw new Exception("User with this email or username already exists.");
        }

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            FullName = request.FullName,
            Role = request.Role,
            IsActive = true
        };

        await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<UserDto>(user);
    }
}
