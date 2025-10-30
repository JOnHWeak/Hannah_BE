using HannahAI.Domain.Entities.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HannahAI.Infrastructure.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(s => s.Code).IsUnique();

        builder.HasOne(s => s.Semester)
            .WithMany(sem => sem.Subjects)
            .HasForeignKey(s => s.SemesterId);
    }
}
