using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Users.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery : PaginationRequest, IRequest<PaginatedList<UserDto>>
{
    // Add any filter properties here, e.g.,
    // public string? Role { get; set; }
}

