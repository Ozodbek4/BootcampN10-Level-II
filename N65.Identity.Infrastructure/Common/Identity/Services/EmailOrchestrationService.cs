using N65.Identity.Application.Common.Notifications.Services;

namespace N65.Identity.Infrastructure.Common.Identity.Services;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    public ValueTask<bool> SendMessageAsync(string emailAddress, string message)
    {
        throw new NotImplementedException();
    }
}