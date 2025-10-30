using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Documents.DTOs;
using HannahAI.Domain.Entities.Knowledge;
using HannahAI.Domain.Enums;
using MediatR;

namespace HannahAI.Application.Features.Documents.Commands.UploadDocument;

// Note: This handler would need a service to save the file to a persistent storage (e.g., IFileStorageService)
// The implementation of that service would be in the Infrastructure layer.
public class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentCommand, DocumentDto>
{
    private readonly IRepository<Document> _documentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UploadDocumentCommandHandler(IRepository<Document> documentRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DocumentDto> Handle(UploadDocumentCommand request, CancellationToken cancellationToken)
    {
        // 1. Save the file to a storage (e.g., local disk, Azure Blob Storage, S3)
        // This logic would be in a dedicated service, e.g., IFileStorageService
        var filePath = $"uploads/{Guid.NewGuid()}_{request.File.FileName}";
        // await _fileStorageService.SaveFileAsync(request.File.OpenReadStream(), filePath);

        // 2. Create metadata entity
        var document = new Document
        {
            FileName = request.File.FileName,
            FilePath = filePath, // Path from the storage service
            ContentType = request.File.ContentType,
            Size = request.File.Length,
            Status = ProcessingStatus.Pending, // Set initial status
            SubjectId = request.SubjectId
        };

        // 3. Save metadata to the database
        await _documentRepository.AddAsync(document, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        // 4. Return DTO
        return _mapper.Map<DocumentDto>(document);
    }
}
