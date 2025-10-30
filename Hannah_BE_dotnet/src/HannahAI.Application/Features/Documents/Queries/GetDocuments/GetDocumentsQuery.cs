using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Documents.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Documents.Queries.GetDocuments;

public class GetDocumentsQuery : PaginationRequest, IRequest<PaginatedList<DocumentDto>>
{
}

