using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Models;

public sealed class Order : IEntity
{
    public const string STATUS_PENDING = "Pending";
    public const string STATUS_COMPLETED = "Completed";
    public const string STATUS_CANCELED = "Canceled";

    public long Id { get; set; }
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;

    public List<OrderItem> Items { get; set; } = [];

    public decimal GetTotalAmount()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            total += item.UnitPrice * item.Quantity;
        }
        return total;
    }
}