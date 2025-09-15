namespace ProjetoBackEndInfnet.Models;

public sealed class Payment
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = null!;
    public DateTime PaymentDate { get; set; } = DateTime.Now;

    public Order? Order { get; set; }

    public bool IsPaid()
    {
        return TotalAmount > 0;
    }
}