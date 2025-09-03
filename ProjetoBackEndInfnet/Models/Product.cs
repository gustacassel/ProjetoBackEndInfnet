using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Models;

public sealed class Product : IEntity
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string MeasureUnit { get; set; } = string.Empty;
    public decimal QuantityInStock { get; set; }
    public bool Active { get; set; } = true;

    public bool IsAvailable(int quantity)
    {
        return Active && QuantityInStock >= quantity;
    }
}