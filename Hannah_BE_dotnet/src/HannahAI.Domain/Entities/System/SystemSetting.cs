using HannahAI.Domain.Entities.Common;

namespace HannahAI.Domain.Entities.System;

public class SystemSetting : BaseEntity
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string? Description { get; set; }
}
