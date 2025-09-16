using Microsoft.EntityFrameworkCore;
using ProjetoBackEndInfnet.Data;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public sealed class AddressRepository : IAddressRepository
{
    private readonly AppDbContext _context;
    public AddressRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Address>> GetAllAsync()
    {
        return await _context
            .Addresses
            .Include(a => a.User)
            .ToListAsync();
    }

    public async Task<Address?> GetByIdAsync(long id)
    {
        return await _context
            .Addresses
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Address address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Address address)
    {
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address != null)
        {
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}