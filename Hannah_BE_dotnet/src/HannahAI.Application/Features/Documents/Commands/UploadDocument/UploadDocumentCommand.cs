using HannahAI.Application.Features.Documents.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HannahAI.Application.Features.Documents.Commands.UploadDocument;

public class UploadDocumentCommand : IRequest<DocumentDto>
{
    public Guid SubjectId { get; set; }
    public IFormFile File { get; set; } = null!;
}
