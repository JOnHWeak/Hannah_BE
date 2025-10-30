using HannahAI.Application.Common.Interfaces;
using HannahAI.Domain.Entities.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HannahAI.Application.Features.Users.Commands.DeactivateUser;

public class DeactivateUserCommandHandler : IRequestHandler<DeactivateUserCommand>
{
    private readonly IRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeactivateUserCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user == null)
        {
            throw new ValidationException("User not found.");
        }

        user.IsActive = false;

        await _unitOfWork.CommitAsync(cancellationToken);

        return;
    }
}
