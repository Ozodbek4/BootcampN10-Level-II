using FileBaseContext.Abstractions.Models.Entity;

namespace N48Home.Api.Models;

public class Order : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public decimal Amount { get; set; }

    public DateTimeOffset OrderedDate { get; set; }

    public bool IsDeleted { get; set; }

    public Order(Guid id, Guid userId, decimal amount)
    {
        Id = id;
        UserId = userId;
        Amount = amount;
    }
}