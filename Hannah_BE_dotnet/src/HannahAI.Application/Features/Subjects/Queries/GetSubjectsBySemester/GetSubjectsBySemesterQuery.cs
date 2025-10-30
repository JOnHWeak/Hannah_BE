using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Subjects.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Subjects.Queries.GetSubjectsBySemester;

public class GetSubjectsBySemesterQuery : PaginationRequest, IRequest<PaginatedList<SubjectDto>>
{
    public Guid SemesterId { get; set; }
}

