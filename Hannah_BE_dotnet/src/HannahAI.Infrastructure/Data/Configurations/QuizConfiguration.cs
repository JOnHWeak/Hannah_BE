using HannahAI.Domain.Entities.Studio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HannahAI.Infrastructure.Data.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(q => q.Subject)
            .WithMany()
            .HasForeignKey(q => q.SubjectId);

        builder.HasMany(q => q.Questions)
            .WithOne(qq => qq.Quiz)
            .HasForeignKey(qq => qq.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
