namespace HannahAI.Application.Features.Auth.DTOs;

public class LoginResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}
