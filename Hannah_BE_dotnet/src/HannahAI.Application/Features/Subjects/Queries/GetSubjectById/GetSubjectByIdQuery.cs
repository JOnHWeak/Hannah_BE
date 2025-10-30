using HannahAI.Application.Features.Subjects.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Subjects.Queries.GetSubjectById;

public class GetSubjectByIdQuery : IRequest<SubjectDto?>
{
    public Guid Id { get; set; }
}
