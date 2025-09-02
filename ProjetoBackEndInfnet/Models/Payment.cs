namespace ProjetoBackEndInfnet.Models;

public class Payment
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }

    public bool IsPaid()
    {
        return TotalAmount > 0;
    }
}