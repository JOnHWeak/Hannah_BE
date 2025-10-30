using AutoMapper;
using AutoMapper.QueryableExtensions;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Documents.DTOs;
using HannahAI.Domain.Entities.Knowledge;
using MediatR;

namespace HannahAI.Application.Features.Documents.Queries.GetDocumentsBySubject;

public class GetDocumentsBySubjectQueryHandler : IRequestHandler<GetDocumentsBySubjectQuery, PaginatedList<DocumentDto>>
{
    private readonly IRepository<Document> _documentRepository;
    private readonly IMapper _mapper;

    public GetDocumentsBySubjectQueryHandler(IRepository<Document> documentRepository, IMapper mapper)
    {
        _documentRepository = documentRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DocumentDto>> Handle(GetDocumentsBySubjectQuery request, CancellationToken cancellationToken)
    {
        var documents = (await _documentRepository.FindAsync(d => d.SubjectId == request.SubjectId, cancellationToken)).AsQueryable();

        var mappedDocuments = documents.ProjectTo<DocumentDto>(_mapper.ConfigurationProvider);

        return PaginatedList<DocumentDto>.Create(mappedDocuments, request.PageNumber, request.PageSize);
    }
}
