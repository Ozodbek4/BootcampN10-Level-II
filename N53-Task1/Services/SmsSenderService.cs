using N53Home1.Events;
using N53Home1.Models;
using N53Home1.Services.Interfaces;

namespace N53Home1.Services;

internal class SmsSenderService : INotificationService
{
    private readonly BonusAchievedEvent BonusAchieved;
    private readonly OrderCreatedEvent OrderCreated;

    public SmsSenderService(BonusAchievedEvent bonusAchievedEvent, OrderCreatedEvent orderCreatedEvent)
    {
        BonusAchieved = bonusAchievedEvent;
        BonusAchieved.OnBonusAchieved += SenderBonusMessageAsync;

        OrderCreated = orderCreatedEvent;
        OrderCreated.OnOrderCreated += SenderOrderMessageAsnyc;
    }

    public ValueTask SenderBonusMessageAsync(IEnumerable<User> users)
    {
        users.ToList().ForEach(user => Console.WriteLine("Sms. Userlarga Bonus message jo'natildi\n" + $"Huramli {user.FirstName} {user.LastName}, sizning keyingi marrangizga {user.Achievment} qoldi"));

        return ValueTask.CompletedTask;
    }

    public ValueTask SenderOrderMessageAsnyc(IEnumerable<User> users)
    {
        users.ToList().ForEach(user => Console.WriteLine("Sms. Userlarga Bonus message jo'natildi"));

        return ValueTask.CompletedTask;
    }
}