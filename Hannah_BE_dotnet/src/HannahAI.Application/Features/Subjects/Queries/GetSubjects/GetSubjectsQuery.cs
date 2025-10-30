using HannahAI.Application.Common.Models;
using HannahAI.Application.Features.Subjects.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Subjects.Queries.GetSubjects;

public class GetSubjectsQuery : PaginationRequest, IRequest<PaginatedList<SubjectDto>>
{
}

