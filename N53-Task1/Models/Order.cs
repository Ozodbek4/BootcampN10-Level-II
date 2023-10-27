namespace N53Home1.Models;

internal class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public decimal Amount { get; set; }

    public bool IsCanceled { get; set; }

    public DateTimeOffset? CanceledDate { get; set; }
}