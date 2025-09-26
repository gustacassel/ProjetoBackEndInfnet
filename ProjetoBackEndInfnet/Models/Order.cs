using System.ComponentModel.DataAnnotations;

namespace ProjetoBackEndInfnet.Models;

public sealed class Order
{
    public const string STATUS_PENDING = "Pendente";
    public const string STATUS_COMPLETED = "Completo";
    public const string STATUS_CANCELED = "Cancelado";

    public long Id { get; set; }

    [Display(Name = "Usuário")]
    [Required(ErrorMessage = "O usuário é obrigatório.")]
    public long UserId { get; set; }

    [Display(Name = "Endereço")]
    [Required(ErrorMessage = "O endereço é obrigatório.")]
    public long AddressId { get; set; }

    [Display(Name = "Data do Pedido")]
    [Required(ErrorMessage = "A data do pedido é obrigatória.")]
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Display(Name = "Status")]
    [Required(ErrorMessage = "O status é obrigatório.")]
    [AllowedValues(STATUS_PENDING, STATUS_COMPLETED, STATUS_CANCELED, ErrorMessage = "Status inválido.")]
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