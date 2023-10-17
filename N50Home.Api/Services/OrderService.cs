using N50Home.Api.DataAccess;
using N50Home.Api.Models;

namespace N50Home.Api.Services;

public class OrderService
{
    public Order GetById(Guid id) =>
        ListService.Orders.FirstOrDefault(order => order.Id == id);

    public IEnumerable<Order> Get(IEnumerable<Order> orders) =>
        ListService.Orders.Where(order =>orders.Any(item => item.Id == order.Id && !item.IsDeleted));

    public Order Create(Order order)
    {
        var created = GetById(order.Id);

        if (created != null)
            return null;

        ListService.Orders.Add(order);

        return order;
    }

    public Order Update(Order order)
    {
        var updated = GetById(order.Id);

        if (updated == null)
            return null;

        updated.UserId = order.UserId;
        updated.Amount = order.Amount;
        updated.OrderedDate = order.OrderedDate;
        updated.IsDeleted = order.IsDeleted;

        return order;
    }

    public Order Delete(Guid id)
    {
        var deleted = GetById(id);

        if (deleted == null)
            return null;

        deleted.IsDeleted = true;
        
        return deleted;
    }
}