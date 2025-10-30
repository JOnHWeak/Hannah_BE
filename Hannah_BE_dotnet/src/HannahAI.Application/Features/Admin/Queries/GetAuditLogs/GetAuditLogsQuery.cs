using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Admin.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Admin.Queries.GetAuditLogs;

public class GetAuditLogsQuery : PaginationRequest, IRequest<PaginatedList<AuditLogDto>>
{
    public Guid? UserId { get; set; }
    public string? EntityName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

