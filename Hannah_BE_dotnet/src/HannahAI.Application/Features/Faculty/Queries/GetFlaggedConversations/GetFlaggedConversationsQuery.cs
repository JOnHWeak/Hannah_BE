using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Faculty.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Faculty.Queries.GetFlaggedConversations;

public class GetFlaggedConversationsQuery : PaginationRequest, IRequest<PaginatedList<FlaggedConversationDto>>
{
    public Guid? SubjectId { get; set; }
}

