namespace ProjetoBackEndInfnet.Entidades;

public class Pagamento
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public decimal ValorTotal { get; set; }
    public string MetodoPagamento { get; set; } = string.Empty;
    public string StatusPagamento { get; set; } = string.Empty;
    public DateTime DataPagamento { get; set; }
}