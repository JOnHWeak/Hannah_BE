using HannahAI.Domain.Entities.Users;
using HannahAI.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace HannahAI.Infrastructure.Data.Seed;

public static class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Note: Password hashing should be done via a service, this is a simplified example.
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Email = "admin@hannah.ai",
                PasswordHash = "hashed_password_for_admin", // Replace with a real hash
                FullName = "Administrator",
                Role = UserRole.Admin,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = Guid.NewGuid(),
                Username = "student",
                Email = "student@hannah.ai",
                PasswordHash = "hashed_password_for_student", // Replace with a real hash
                FullName = "Demo Student",
                Role = UserRole.Student,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}

