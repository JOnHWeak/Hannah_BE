using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Academic;

public class Subject : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }

    public Guid SemesterId { get; set; }
    public Semester Semester { get; set; } = null!;
}
