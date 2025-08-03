namespace ProjetoBackEndInfnet.Entidades;

public class ItemCarrinho
{
    public int Id { get; set; }
    public int CarrinhoId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
}