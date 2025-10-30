using HannahAI.Domain.Repositories;

namespace HannahAI.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly HannahDbContext _context;

    public UnitOfWork(HannahDbContext context)
    {
        _context = context;
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

