using Microsoft.EntityFrameworkCore;
using ProjetoBackEndInfnet.Data;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(long id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        _context.Products.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var product = await GetByIdAsync(id);
        if (product is not null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public Task<List<Product>> GetAllActiveProductsAsync()
    {
        return _context.Products.Where(p => p.Active).ToListAsync();
    }

    public async Task<bool> IsInStock(long productId, decimal quantity)
    {
        var product = await GetByIdAsync(productId);
        if (product is null)
        {
            return false;
        }

        return product.IsInStock(quantity);
    }
}