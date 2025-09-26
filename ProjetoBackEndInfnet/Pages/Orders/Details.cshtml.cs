using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Orders;

public sealed class DetailsModel : PageModel
{
    public Order Order { get; set; } = null!;

    private readonly IOrderRepository _orderRepository;
    public DetailsModel(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IActionResult> OnGetAsync(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await _orderRepository.GetByIdAsync(id.Value);

        if (order == null)
        {
            return NotFound();
        }

        Order = order;

        return Page();
    }
}