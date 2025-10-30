using Microsoft.AspNetCore.Http;

namespace HannahAI.Application.Features.Documents.DTOs;

public class UploadDocumentRequest
{
    public Guid SubjectId { get; set; }
    public IFormFile File { get; set; } = null!;
}
