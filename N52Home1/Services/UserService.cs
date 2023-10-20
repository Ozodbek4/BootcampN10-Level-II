using N52Home1.Models;

namespace N52Home1.Services;

internal class UserService
{
    public async ValueTask<User> CreateUserAsycn(User user)
    {
        Console.WriteLine("User yartildi");
        return user;
    }
}