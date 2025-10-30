using HannahAI.Application.Features.Documents.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Documents.Queries.GetDocumentById;

public class GetDocumentByIdQuery : IRequest<DocumentDto?>
{
    public Guid Id { get; set; }
}
