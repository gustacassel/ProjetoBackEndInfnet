using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Addresses;

public sealed class IndexModel : PageModel
{
    public List<Address> Addresses { get; set; } = [];

    private readonly IAddressRepository _repository;
    public IndexModel(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGetAsync()
    {
        Addresses = await _repository.GetAllAsync();
    }
}