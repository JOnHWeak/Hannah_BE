using HannahAI.Domain.Entities.Users;

namespace HannahAI.Infrastructure.Data.Repositories;

// Example of a specialized repository. Can add user-specific methods here.
public class UserRepository : Repository<User>
{
    public UserRepository(HannahDbContext context) : base(context)
    {
    }

    // Example of a specific method:
    // public async Task<User?> GetUserWithProfileAsync(Guid id)
    // {
    //     return await _context.Users.Include(u => u.Profile).FirstOrDefaultAsync(u => u.Id == id);
    // }
}

