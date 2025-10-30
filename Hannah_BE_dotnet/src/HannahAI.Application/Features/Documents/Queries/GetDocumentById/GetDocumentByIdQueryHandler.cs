using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Documents.DTOs;
using HannahAI.Domain.Entities.Knowledge;
using MediatR;

namespace HannahAI.Application.Features.Documents.Queries.GetDocumentById;

public class GetDocumentByIdQueryHandler : IRequestHandler<GetDocumentByIdQuery, DocumentDto?>
{
    private readonly IRepository<Document> _documentRepository;
    private readonly IMapper _mapper;

    public GetDocumentByIdQueryHandler(IRepository<Document> documentRepository, IMapper mapper)
    {
        _documentRepository = documentRepository;
        _mapper = mapper;
    }

    public async Task<DocumentDto?> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        var document = await _documentRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<DocumentDto?>(document);
    }
}
