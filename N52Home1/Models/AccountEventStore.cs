using System.Diagnostics.Tracing;

namespace N52Home1.Models;

internal class AccountEventStore
{
    public event Func<User,ValueTask> OnUserCreated;

    public async ValueTask CreateEventAsync(User user)
    {
        if (OnUserCreated != null)
            await OnUserCreated(user);
    }
}