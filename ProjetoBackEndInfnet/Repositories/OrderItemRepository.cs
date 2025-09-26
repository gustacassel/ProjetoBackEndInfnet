using Microsoft.EntityFrameworkCore;
using ProjetoBackEndInfnet.Data;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public sealed class OrderItemRepository : IOrderItemRepository
{
    private readonly AppDbContext _context;
    public OrderItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<OrderItem?> GetByIdAsync(long id)
    {
        return await _context.OrderItems
            .Include(oi => oi.Product)
            .FirstOrDefaultAsync(oi => oi.Id == id);
    }

    public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(long orderId)
    {
        return await _context.OrderItems
            .Include(oi => oi.Product)
            .Where(oi => oi.OrderId == orderId)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
    {
        return await _context.OrderItems.ToListAsync();
    }

    public async Task AddAsync(OrderItem orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderItem orderItem)
    {
        _context.OrderItems.Update(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var orderItem = await _context.OrderItems.FindAsync(id);
        if (orderItem != null)
        {
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}