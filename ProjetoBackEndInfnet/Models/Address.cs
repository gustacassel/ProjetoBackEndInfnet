namespace ProjetoBackEndInfnet.Models;

public sealed class Address
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Neighborhood { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string? Complement { get; set; }

    public User? User { get; set; }
}