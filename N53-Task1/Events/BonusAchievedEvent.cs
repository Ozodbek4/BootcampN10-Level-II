using N53Home1.Models;

namespace N53Home1.Events;

internal class BonusAchievedEvent
{
    public event Func<IEnumerable<User>, ValueTask> OnBonusAchieved;

    public async ValueTask CreatedEventAsync(IEnumerable<User> users)
    {
        if (OnBonusAchieved != null)
            await OnBonusAchieved(users);
    }
}