using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Orders;

public sealed class IndexModel : PageModel
{
    public List<Order> Orders { get; set; } = new List<Order>();

    private readonly IOrderRepository _repository;
    public IndexModel(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGetAsync()
    {
        Orders = await _repository.GetAllAsync();
    }
}