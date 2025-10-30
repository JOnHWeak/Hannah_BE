using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Admin.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Admin.Queries.GetApiUsage;

public class GetApiUsageQuery : PaginationRequest, IRequest<PaginatedList<ApiUsageDto>>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

