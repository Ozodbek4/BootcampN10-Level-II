using N52Home1.Models;

namespace N52Home1.Services;

internal class UserFoundationService
{
    public readonly UserService _userService;
    public readonly AccountEventStore _accountEventStore;

    public UserFoundationService(UserService userService, AccountEventStore accountEventStore)
    {
        _userService = userService;
        _accountEventStore = accountEventStore;
    }

    public async ValueTask Create(User user)
    {
        var newUser = await _userService.CreateUserAsycn(user);
        Console.WriteLine("working foundation service");
        await _accountEventStore.CreateEventAsync(newUser);
    }
}