using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Auth.DTOs;
using HannahAI.Application.Features.Auth.Services;
using HannahAI.Domain.Entities.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HannahAI.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenResponse>
{
    private readonly IRepository<UserSession> _sessionRepository;
    private readonly IRepository<User> _userRepository;
    private readonly ITokenService _tokenService;

    public RefreshTokenCommandHandler(IRepository<UserSession> sessionRepository, IRepository<User> userRepository, ITokenService tokenService)
    {
        _sessionRepository = sessionRepository;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<TokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var session = (await _sessionRepository.FindAsync(s => s.RefreshToken == request.RefreshToken && !s.IsRevoked && s.ExpiresAt > DateTime.UtcNow, cancellationToken)).FirstOrDefault();

        if (session == null)
        {
            throw new ValidationException("Invalid refresh token.");
        }

        var user = await _userRepository.GetByIdAsync(session.UserId, cancellationToken);

        if (user == null)
        {
            throw new ValidationException("User not found.");
        }

        var newAccessToken = _tokenService.GenerateAccessToken(user);

        return new TokenResponse
        {
            AccessToken = newAccessToken
        };
    }
}
