using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Models;

public sealed class User : IEntity
{
    public const string ROLE_USER = "User";
    public const string ROLE_ADMIN = "Admin";

    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // "User" or "Admin"

    public bool IsAdmin()
    {
        return Role.Equals(ROLE_ADMIN, StringComparison.OrdinalIgnoreCase);
    }
}