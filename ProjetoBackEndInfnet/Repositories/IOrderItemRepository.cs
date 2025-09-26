using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public interface IOrderItemRepository
{
    Task<OrderItem?> GetByIdAsync(long id);
    Task<IEnumerable<OrderItem>> GetByOrderIdAsync(long orderId);
    Task<IEnumerable<OrderItem>> GetAllAsync();
    Task AddAsync(OrderItem orderItem);
    Task UpdateAsync(OrderItem orderItem);
    Task DeleteAsync(long id);
}