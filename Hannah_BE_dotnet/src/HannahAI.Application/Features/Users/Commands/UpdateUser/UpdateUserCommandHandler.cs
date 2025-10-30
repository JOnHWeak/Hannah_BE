using HannahAI.Application.Common.Interfaces;
using HannahAI.Domain.Entities.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HannahAI.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user == null)
        {
            throw new ValidationException("User not found.");
        }

        if (request.FullName != null)
        {
            user.FullName = request.FullName;
        }
        if (request.Role.HasValue)
        {
            user.Role = request.Role.Value;
        }
        if (request.IsActive.HasValue)
        {
            user.IsActive = request.IsActive.Value;
        }

        await _unitOfWork.CommitAsync(cancellationToken);

        return;
    }
}
