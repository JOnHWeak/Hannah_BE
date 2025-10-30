using HannahAI.Application.Features.Subjects.DTOs;
using MediatR;

namespace HannahAI.Application.Features.Subjects.Commands.CreateSubject;

public class CreateSubjectCommand : IRequest<SubjectDto>
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public Guid SemesterId { get; set; }
}
