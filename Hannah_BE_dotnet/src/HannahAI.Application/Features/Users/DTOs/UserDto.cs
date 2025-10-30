using HannahAI.Domain.Enums;

namespace HannahAI.Application.Features.Users.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public UserRole Role { get; set; }
    public bool IsActive { get; set; }
}
