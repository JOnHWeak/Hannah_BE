using HannahAI.Domain.Entities.Academic;

namespace HannahAI.Infrastructure.Data.Repositories;

public class SubjectRepository : Repository<Subject>
{
    public SubjectRepository(HannahDbContext context) : base(context)
    {
    }
}

