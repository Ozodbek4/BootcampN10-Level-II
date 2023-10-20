using N52Home1.Models;

namespace N52Home1.Services;

internal class AccountNotificationService
{
    public readonly AccountEventStore _accountEventStore;

    public AccountNotificationService(AccountEventStore accountEventStore)
    {
        _accountEventStore = accountEventStore;
        _accountEventStore.OnUserCreated += SenderAsycn;
        //_accountEventStore.OnUserCreated -= SenderAsycn;
        _accountEventStore.OnUserCreated += Update;
    }

    public ValueTask SenderAsycn(User user)
    {
        Console.WriteLine($"Dear {user.FirstName} you have successfully registereted");
        return ValueTask.CompletedTask;
    }

    public ValueTask Update(User user)
    {
        Console.WriteLine("Updated");
        return ValueTask.CompletedTask;
    }
}