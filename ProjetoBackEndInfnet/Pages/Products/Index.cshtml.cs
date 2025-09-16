using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Products;

public sealed class IndexModel : PageModel
{
    public List<Product> Products { get; set; } = [];

    private readonly IProductRepository _repository;
    public IndexModel(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGetAsync()
    {
        Products = await _repository.GetAllAsync();
    }
}