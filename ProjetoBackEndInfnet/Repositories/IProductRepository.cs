using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(long id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(long id);
    Task<List<Product>> GetAllActiveProductsAsync();
    Task<bool> IsInStock(long productId, decimal quantity);
}