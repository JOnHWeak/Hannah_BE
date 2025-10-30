using MediatR;

namespace HannahAI.Application.Features.Auth.Queries.ValidateToken;

public class ValidateTokenQuery : IRequest<bool>
{
    public string AccessToken { get; set; } = null!;
}
