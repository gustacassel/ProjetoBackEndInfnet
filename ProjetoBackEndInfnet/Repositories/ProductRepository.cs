using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public sealed class ProductRepository : BaseRepository<Product>
{
    public ProductRepository() : base("products.json")
    { }
}