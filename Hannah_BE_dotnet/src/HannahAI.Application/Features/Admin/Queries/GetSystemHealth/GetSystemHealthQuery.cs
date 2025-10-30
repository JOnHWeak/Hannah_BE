using HannahAI.Application.Features.Admin.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Admin.Queries.GetSystemHealth;

public class GetSystemHealthQuery : IRequest<SystemHealthDto>
{
}

