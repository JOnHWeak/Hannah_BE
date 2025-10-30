using HannahAI.Domain.Enums;
using MediatR;

namespace HannahAI.Application.Features.Users.Commands.UpdateProfile;

public class UpdateProfileCommand : IRequest
{
    public Guid UserId { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }
    public string? StudentId { get; set; }
    public StudentSpecialty? Specialty { get; set; }
}
