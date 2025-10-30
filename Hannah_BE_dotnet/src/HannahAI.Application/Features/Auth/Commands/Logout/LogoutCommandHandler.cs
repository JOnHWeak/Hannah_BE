using HannahAI.Application.Common.Interfaces;
using HannahAI.Domain.Entities.Users;
using MediatR;

namespace HannahAI.Application.Features.Auth.Commands.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
{
    private readonly IRepository<UserSession> _sessionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LogoutCommandHandler(IRepository<UserSession> sessionRepository, IUnitOfWork unitOfWork)
    {
        _sessionRepository = sessionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var session = (await _sessionRepository.FindAsync(s => s.RefreshToken == request.RefreshToken, cancellationToken)).FirstOrDefault();

        if (session != null)
        {
            session.IsRevoked = true;
            // await _unitOfWork.CommitAsync(cancellationToken);
        }

        return;
    }
}
