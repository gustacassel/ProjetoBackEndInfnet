using System.ComponentModel.DataAnnotations;

namespace ProjetoBackEndInfnet.Models;

public sealed class Address
{
    public long Id { get; set; }
    public long UserId { get; set; }

    [Display(Name = "Rua")]
    [Required(ErrorMessage = "O campo Rua é obrigatório.")]
    public string Street { get; set; } = null!;

    [Display(Name = "Número")]
    [Required(ErrorMessage = "O campo Número é obrigatório.")]
    public string Number { get; set; } = null!;

    [Display(Name = "Bairro")]
    [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
    public string Neighborhood { get; set; } = null!;

    [Display(Name = "Cidade")]
    [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
    public string City { get; set; } = null!;

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "O campo Estado é obrigatório.")]
    [StringLength(2, ErrorMessage = "O campo Estado deve ter exatamente 2 caracteres.")]
    public string State { get; set; } = null!;

    [Display(Name = "CEP")]
    [Required(ErrorMessage = "O campo CEP é obrigatório.")]
    public string ZipCode { get; set; } = null!;

    [Display(Name = "Complemento")]
    public string? Complement { get; set; }

    [Display(Name = "Ativo")]
    public bool Active { get; set; } = true;

    public User? User { get; set; }
}