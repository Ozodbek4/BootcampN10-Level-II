using N53Home1.Events;
using N53Home1.Models;

namespace N53Home1.Services;

internal class UserPromotionService
{
    public readonly BonusAchievedEvent BonusAchieved;

    public UserPromotionService(BonusAchievedEvent bonusAchieved)
    {
        BonusAchieved = bonusAchieved;
    }

    public async ValueTask Create(IEnumerable<User> users)
    {
        Console.WriteLine("Working UserPromotionService...");
        await BonusAchieved.CreatedEventAsync(users);
    }
}