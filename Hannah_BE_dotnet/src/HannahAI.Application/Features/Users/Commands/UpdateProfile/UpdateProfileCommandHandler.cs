using HannahAI.Application.Common.Interfaces;
using HannahAI.Domain.Entities.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HannahAI.Application.Features.Users.Commands.UpdateProfile;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
{
    private readonly IRepository<UserProfile> _profileRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProfileCommandHandler(IRepository<UserProfile> profileRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
    {
        _profileRepository = profileRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            throw new ValidationException("User not found.");
        }

        var profile = (await _profileRepository.FindAsync(p => p.UserId == request.UserId, cancellationToken)).FirstOrDefault();

        if (profile == null)
        {
            profile = new UserProfile { UserId = request.UserId };
            await _profileRepository.AddAsync(profile, cancellationToken);
        }

        profile.AvatarUrl = request.AvatarUrl ?? profile.AvatarUrl;
        profile.Bio = request.Bio ?? profile.Bio;
        profile.StudentId = request.StudentId ?? profile.StudentId;
        profile.Specialty = request.Specialty ?? profile.Specialty;

        await _unitOfWork.CommitAsync(cancellationToken);

        return;
    }
}
