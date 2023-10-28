using N53Home1.Models;

namespace N53Home1.Data;

internal static class UsersList
{
    public static List<User> Users = new List<User>()
    {
        new User(){Id = Guid.NewGuid(), FirstName = "Ali", LastName = "Qodirov", EmailAddress = "aliqodirov@gmail.com", Password = "aliqorDirov"},
        new User(){Id = Guid.NewGuid(), FirstName = "Mahmud", LastName = "Raximov", EmailAddress = "maxmudraximov@gmail.com", Password = "maxmudjon"},
        new User(){Id = Guid.NewGuid(), FirstName = "Karimkhon", LastName = "Rarhimkhonov", EmailAddress = "husunovkarim@gmail.com", Password = "karimjon"}
    };

    public static List<Order> Orders = new List<Order>()
    {
        new Order(){Id = Guid.NewGuid(), UserId = Users[0].Id, Amount = 1000, IsCanceled = false},
        new Order(){Id = Guid.NewGuid(), UserId = Users[1].Id, Amount = 2000, IsCanceled = false},
        new Order(){Id = Guid.NewGuid(), UserId = Users[2].Id, Amount = 3000, IsCanceled = false},
    };

    public static List<Bonus> Bonuses = new List<Bonus>()
    {
        new Bonus(){Id = Guid.NewGuid(), UserId = Users[0].Id, Amount = 10},
        new Bonus(){Id = Guid.NewGuid(), UserId = Users[1].Id, Amount = 10},
        new Bonus(){Id = Guid.NewGuid(), UserId = Users[2].Id, Amount = 30},
    };
}
