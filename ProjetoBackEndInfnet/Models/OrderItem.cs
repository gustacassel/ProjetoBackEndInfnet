using System.ComponentModel.DataAnnotations;

namespace ProjetoBackEndInfnet.Models;

public sealed class OrderItem
{
    public long Id { get; set; }

    [Display(Name = "Pedido")]
    [Required(ErrorMessage = "O pedido é obrigatório.")]
    public long OrderId { get; set; }

    [Display(Name = "Produto")]
    [Required(ErrorMessage = "O produto é obrigatório.")]
    public long ProductId { get; set; }

    [Display(Name = "Quantidade")]
    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    [Range(0.01, int.MaxValue, ErrorMessage = "A quantidade deve ser pelo menos 0,01.")]
    public decimal Quantity { get; set; }

    [Display(Name = "Preço Unitário")]
    [Required(ErrorMessage = "O preço unitário é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço unitário deve ser pelo menos 0,01.")]
    public decimal UnitPrice { get; set; }

    public Order? Order { get; set; }
    public Product? Product { get; set; }
}