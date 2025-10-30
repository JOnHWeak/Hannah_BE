using HannahAI.Domain.Enums;

namespace HannahAI.Application.Features.Documents.DTOs;

public class DocumentDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public long Size { get; set; }
    public ProcessingStatus Status { get; set; }
    public Guid SubjectId { get; set; }
    public DateTime CreatedAt { get; set; }
}
