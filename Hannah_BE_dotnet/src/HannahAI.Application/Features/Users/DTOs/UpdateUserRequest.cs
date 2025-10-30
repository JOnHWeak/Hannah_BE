using HannahAI.Domain.Enums;

namespace HannahAI.Application.Features.Users.DTOs;

public class UpdateUserRequest
{
    public string? FullName { get; set; }
    public UserRole? Role { get; set; }
    public bool? IsActive { get; set; }
}
