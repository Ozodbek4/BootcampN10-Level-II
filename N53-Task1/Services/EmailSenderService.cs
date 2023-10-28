using N53Home1.Events;
using N53Home1.Models;
using N53Home1.Services.Interfaces;

namespace N53Home1.Services;

internal class EmailSenderService : INotificationService
{
    public readonly BonusAchievedEvent BonusAchievement;
    public readonly OrderCreatedEvent OrderCreated;

    public EmailSenderService(BonusAchievedEvent bonusAchievement, OrderCreatedEvent orderCreated)
    {
        BonusAchievement = bonusAchievement;
        BonusAchievement.OnBonusAchieved += SenderBonusMessageAsync;

        OrderCreated = orderCreated;
        orderCreated.OnOrderCreated += SenderOrderMessageAsnyc;
    }

    public ValueTask SenderBonusMessageAsync(IEnumerable<User> users)
    {
        users.ToList().ForEach(user => Console.WriteLine("Email. Userlarga Order message jo'natildi\n" + $"Huramli {user.FirstName} {user.LastName}, sizning keyingi marrangizga {user.Achievment} qoldi"));

        return ValueTask.CompletedTask;
    }

    public ValueTask SenderOrderMessageAsnyc(IEnumerable<User> users)
    {
        users.ToList().ForEach(user => Console.WriteLine("Email. Userlarga Order message jo'natildi"));

        return ValueTask.CompletedTask;
    }
}