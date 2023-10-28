using N53Home1.Data;
using N53Home1.Events;
using N53Home1.Models;

namespace N53Home1.Services;

internal class UserBonusService
{
    public readonly BonusAchievedEvent BonusAchiement;

    public UserBonusService(BonusAchievedEvent orderCreatedEvent)
    {
        BonusAchiement = orderCreatedEvent;
    }

    public async ValueTask Create(IEnumerable<User> users)
    {
        await AddAmoutBonus(users);
        GetUsers(users);
        
        await BonusAchiement.CreatedEventAsync(users);
    }

    private IEnumerable<User> GetUsers(IEnumerable<User> users)
    {
        users.ToList().ForEach(item =>
        {
            item.Achievment = AchieveToBonus(UsersList.Bonuses.FirstOrDefault(achieve => users.Any(x => achieve.UserId == x.Id)).Amount);
        });
        return users;
    }

    private decimal AchieveToBonus(decimal amount)
    {
        var xonalarSoni = amount.ToString().Count();

        var qoldiq = (decimal)1;

        for(var i = 0; i < xonalarSoni; i++)
            qoldiq *= 10;

        return qoldiq - amount;
    }

    private ValueTask AddAmoutBonus(IEnumerable<User> users)
    {
        var orderAmount = UsersList.Orders.Where(order => users.Any(user => order.UserId == user.Id)).ToList();
        var bonus = UsersList.Bonuses.Where(bonus => users.Any(user => bonus.UserId == user.Id)).ToList();

        for (var i = 0; i < orderAmount.Count(); i++)
        {
            var searchBonus = bonus.FirstOrDefault(item => item.UserId == orderAmount[i].UserId);
            if (searchBonus is null)
                throw new ArgumentNullException("Bonus is not found");

            searchBonus.Amount += orderAmount[i].Amount;
        }

        return ValueTask.CompletedTask;
    }
}