using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(long id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(long id);
    Task<List<Order>> GetByUserIdAsync(long userId);
    Task<List<Order>> GetByStatusAsync(string status);
}