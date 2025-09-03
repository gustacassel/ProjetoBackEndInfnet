using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Models;

public sealed class OrderItem : IEntity
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}