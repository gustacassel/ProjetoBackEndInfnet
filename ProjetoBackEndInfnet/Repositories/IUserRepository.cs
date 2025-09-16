using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(long id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(long id);
    Task<int> GetCountAsync();
    Task<User?> GetByEmailAsync(string email);
}