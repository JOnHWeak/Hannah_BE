using AutoMapper;
using AutoMapper.QueryableExtensions;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Documents.DTOs;
using HannahAI.Domain.Entities.Knowledge;
using MediatR;

namespace HannahAI.Application.Features.Documents.Queries.GetDocuments;

public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, PaginatedList<DocumentDto>>
{
    private readonly IRepository<Document> _documentRepository;
    private readonly IMapper _mapper;

    public GetDocumentsQueryHandler(IRepository<Document> documentRepository, IMapper mapper)
    {
        _documentRepository = documentRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DocumentDto>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = (await _documentRepository.GetAllAsync(cancellationToken)).AsQueryable();

        var mappedDocuments = documents.ProjectTo<DocumentDto>(_mapper.ConfigurationProvider);

        return PaginatedList<DocumentDto>.Create(mappedDocuments, request.PageNumber, request.PageSize);
    }
}
