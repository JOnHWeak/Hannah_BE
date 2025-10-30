using HannahAI.Domain.Enums;

namespace HannahAI.Application.Features.Users.DTOs;

public class UserProfileDto
{
    public Guid UserId { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }
    public string? StudentId { get; set; }
    public StudentSpecialty? Specialty { get; set; }
}
