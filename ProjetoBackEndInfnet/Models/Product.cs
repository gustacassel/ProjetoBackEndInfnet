using System.ComponentModel.DataAnnotations;

namespace ProjetoBackEndInfnet.Models;

public sealed class Product
{
    public long Id { get; set; }

    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Preço Unitário")]
    [Required(ErrorMessage = "O preço unitário é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Price { get; set; }

    [Display(Name = "Unidade de Medida")]
    [Required(ErrorMessage = "A unidade de medida é obrigatória.")]
    public string MeasureUnit { get; set; } = string.Empty;

    [Display(Name = "Quantidade em Estoque")]
    [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
    public decimal QuantityInStock { get; set; }

    [Display(Name = "Ativo")]
    public bool Active { get; set; } = true;

    public bool IsInStock(decimal quantity)
    {
        return Active && QuantityInStock >= quantity;
    }

    public List<OrderItem> OrderItems { get; set; } = [];
}