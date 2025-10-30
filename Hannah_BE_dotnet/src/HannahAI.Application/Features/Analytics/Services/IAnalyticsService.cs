using HannahAI.Application.Features.Analytics.DTOs;

namespace HannahAI.Application.Features.Analytics.Services;

public interface IAnalyticsService
{
    Task<UserAnalyticsDto> GetUserAnalyticsAsync(Guid userId);
    Task<SubjectAnalyticsDto> GetSubjectAnalyticsAsync(Guid subjectId);
}

