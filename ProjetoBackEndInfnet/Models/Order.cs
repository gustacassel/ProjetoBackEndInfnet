namespace ProjetoBackEndInfnet.Models;

public sealed class Order
{
    public const string STATUS_PENDING = "Pending";
    public const string STATUS_COMPLETED = "Completed";
    public const string STATUS_CANCELED = "Canceled";

    public long Id { get; set; }
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string Status { get; set; } = string.Empty;

    public User? User { get; set; }
    public Address? Address { get; set; }
    public Payment? Payment { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];

    public decimal GetTotalAmount()
    {
        decimal total = 0;
        foreach (var item in OrderItems)
        {
            total += item.UnitPrice * item.Quantity;
        }
        return total;
    }
}