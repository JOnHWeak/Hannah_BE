using HannahAI.Domain.Entities.Academic;
using HannahAI.Domain.Entities.Analytics;
using HannahAI.Domain.Entities.Conversation;
using HannahAI.Domain.Entities.Knowledge;
using HannahAI.Domain.Entities.Progress;
using HannahAI.Domain.Entities.Studio;
using HannahAI.Domain.Entities.System;
using HannahAI.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HannahAI.Infrastructure.Data;

public class HannahDbContext : DbContext // If using Identity, this would be IdentityDbContext<User, Role, Guid>
{
    public HannahDbContext(DbContextOptions<HannahDbContext> options) : base(options)
    {
    }

    // Users
    public DbSet<User> Users => Set<User>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<UserSession> UserSessions => Set<UserSession>();

    // Academic
    public DbSet<Semester> Semesters => Set<Semester>();
    public DbSet<Subject> Subjects => Set<Subject>();

    // Knowledge
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<FAQ> FAQs => Set<FAQ>();

    // Studio
    public DbSet<Quiz> Quizzes => Set<Quiz>();
    public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
    public DbSet<QuizAnswer> QuizAnswers => Set<QuizAnswer>();
    public DbSet<QuizAttempt> QuizAttempts => Set<QuizAttempt>();
    public DbSet<FlashcardSet> FlashcardSets => Set<FlashcardSet>();
    public DbSet<Flashcard> Flashcards => Set<Flashcard>();
    public DbSet<MindMap> MindMaps => Set<MindMap>();
    public DbSet<MindMapCycle> MindMapCycles => Set<MindMapCycle>();
    public DbSet<Report> Reports => Set<Report>();

    // Progress
    public DbSet<UserSubjectProgress> UserSubjectProgresses => Set<UserSubjectProgress>();
    public DbSet<UserConceptMastery> UserConceptMasteries => Set<UserConceptMastery>();

    // Analytics
    public DbSet<AnalyticsEvent> AnalyticsEvents => Set<AnalyticsEvent>();
    public DbSet<AIResponseRating> AIResponseRatings => Set<AIResponseRating>();

    // System
    public DbSet<SystemSetting> SystemSettings => Set<SystemSetting>();
    public DbSet<ApiUsageLog> ApiUsageLogs => Set<ApiUsageLog>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<SavedResource> SavedResources => Set<SavedResource>();

    // Conversation
    public DbSet<ConversationMetadata> ConversationMetadata => Set<ConversationMetadata>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
