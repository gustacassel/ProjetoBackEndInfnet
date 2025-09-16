using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public interface IAddressRepository
{
    Task<List<Address>> GetAllAsync();
    Task<Address?> GetByIdAsync(long id);
    Task AddAsync(Address address);
    Task UpdateAsync(Address address);
    Task DeleteAsync(long id);
}