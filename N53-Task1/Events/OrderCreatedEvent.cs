using N53Home1.Models;

namespace N53Home1.Events;

internal class OrderCreatedEvent
{
    public event Func<IEnumerable<User>, ValueTask> OnOrderCreated;

    public async ValueTask CreatedEventAsync(IEnumerable<User> users)
    {
        if (OnOrderCreated != null)
            await OnOrderCreated(users);
    }
}