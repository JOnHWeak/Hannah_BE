using System;

namespace HannahAI.Infrastructure.Services;

// A simple service to allow for mocking DateTime.UtcNow in tests
public interface IDateTimeService
{
    DateTime UtcNow { get; }
}

public class DateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}

