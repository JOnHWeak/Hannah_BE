using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Users.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Admin.Queries.GetAllUsers;

public class GetAllUsersQuery : PaginationRequest, IRequest<PaginatedList<UserDto>>
{
}

