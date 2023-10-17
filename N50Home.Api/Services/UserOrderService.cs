using Microsoft.AspNetCore.Authorization;
using N50Home.Api.DataAccess;
using N50Home.Api.Models; 

namespace N50Home.Api.Services;

public class UserOrderService
{
    public Tuple<User, IEnumerable<Order>> GetUserOrdersByUserId(Guid userId) =>
         ListService.Users.GroupJoin(ListService.Orders,
            user => user.Id,
            order => order.UserId,
            (user, order) => new Tuple<User, IEnumerable<Order>>(user,order))
        .FirstOrDefault(user => user.Item1.Id == userId)!;
}