using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Auth.DTOs;
using HannahAI.Application.Features.Auth.Services;
using HannahAI.Domain.Entities.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HannahAI.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IRepository<User> _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;

    public LoginCommandHandler(IRepository<User> userRepository, IPasswordHasher passwordHasher, ITokenService tokenService, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.FindAsync(u => u.Email == request.Email, cancellationToken)).FirstOrDefault();

        if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            throw new ValidationException("Invalid email or password.");
        }

        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        var userSession = new UserSession
        {
            UserId = user.Id,
            RefreshToken = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(7) // Example expiration
        };

        // You would typically save the user session to the database here
        // await _unitOfWork.Repository<UserSession>().AddAsync(userSession, cancellationToken);
        // await _unitOfWork.CommitAsync(cancellationToken);

        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}
