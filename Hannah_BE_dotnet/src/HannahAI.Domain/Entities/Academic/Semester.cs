using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.Academic;

public class Semester : BaseEntity
{
    public string Name { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
