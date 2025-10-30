using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Documents.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Documents.Queries.GetDocumentsBySubject;

public class GetDocumentsBySubjectQuery : PaginationRequest, IRequest<PaginatedList<DocumentDto>>
{
    public Guid SubjectId { get; set; }
}

