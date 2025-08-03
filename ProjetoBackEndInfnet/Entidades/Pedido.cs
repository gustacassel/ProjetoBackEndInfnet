namespace ProjetoBackEndInfnet.Entidades;

public class Pedido
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int EnderecoId { get; set; }
    public DateTime DataPedido { get; set; }
    public string Status { get; set; } = string.Empty;
    public string NumeroPedido { get; set; } = string.Empty;
}