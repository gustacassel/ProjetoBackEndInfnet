using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Users;

public sealed class IndexModel : PageModel
{
    public List<User> Users { get; set; } = [];

    private readonly IUserRepository _repository;
    public IndexModel(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGetAsync()
    {
        Users = await _repository.GetAllAsync();
    }
}