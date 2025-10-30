using MediatR;

namespace HannahAI.Application.Features.Admin.Commands.UpdateSystemSettings;

public class UpdateSystemSettingsCommand : IRequest
{
    public Dictionary<string, string> Settings { get; set; } = new();
}
