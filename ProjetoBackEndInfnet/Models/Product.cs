using System.ComponentModel.DataAnnotations;

namespace ProjetoBackEndInfnet.Models;

public sealed class Product
{
    public long Id { get; set; }

    [Display(Name = "Descrição")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Preço Unitário")]
    public decimal Price { get; set; }

    [Display(Name = "Unidade de Medida")]
    public string MeasureUnit { get; set; } = string.Empty;

    [Display(Name = "Quantidade em Estoque")]
    public decimal QuantityInStock { get; set; }

    [Display(Name = "Ativo")]
    public bool Active { get; set; } = true;

    public bool IsInStock(decimal quantity)
    {
        return Active && QuantityInStock >= quantity;
    }
}