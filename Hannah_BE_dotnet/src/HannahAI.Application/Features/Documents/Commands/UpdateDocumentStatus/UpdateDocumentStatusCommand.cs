using HannahAI.Domain.Enums;
using MediatR;

namespace HannahAI.Application.Features.Documents.Commands.UpdateDocumentStatus;

public class UpdateDocumentStatusCommand : IRequest
{
    public Guid DocumentId { get; set; }
    public ProcessingStatus NewStatus { get; set; }
}
