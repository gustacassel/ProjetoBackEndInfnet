using System.ComponentModel.DataAnnotations;

namespace ProjetoBackEndInfnet.Models;

public sealed class User
{
    public const string ROLE_USER = "User";
    public const string ROLE_ADMIN = "Admin";

    public long Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Email")]
    [Required(ErrorMessage = "O email é obrigatório.")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Senha")]
    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Função")]
    [Required(ErrorMessage = "A função é obrigatória.")]
    [RegularExpression("^(User|Admin)$", ErrorMessage = "A função deve ser 'User' ou 'Admin'.")]
    public string Role { get; set; } = string.Empty; // "User" or "Admin"

    [Display(Name = "Ativo")]
    public bool Active { get; set; } = true;

    public List<Address> Addresses { get; set; } = [];
    public List<Order> Orders { get; set; } = [];

    public bool IsAdmin()
    {
        return Role.Equals(ROLE_ADMIN, StringComparison.OrdinalIgnoreCase);
    }
}