using MediatR;

namespace HannahAI.Application.Features.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommand : IRequest
{
    public Guid DocumentId { get; set; }
}
