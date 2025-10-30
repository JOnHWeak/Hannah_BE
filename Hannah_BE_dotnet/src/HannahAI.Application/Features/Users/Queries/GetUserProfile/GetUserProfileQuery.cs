using HannahAI.Application.Features.Users.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Users.Queries.GetUserProfile;

public class GetUserProfileQuery : IRequest<UserProfileDto?>
{
    public Guid UserId { get; set; }
}
