using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.OrderItems;

public sealed class IndexModel : PageModel
{
    public Order? Order { get; set; }

    private readonly IOrderRepository _orderRepository;
    public IndexModel(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IActionResult> OnGetAsync(long orderId)
    {
        Order = await _orderRepository.GetByIdAsync(orderId);
        if (Order is null)
        {
            return NotFound();
        }
        return Page();
    }
}
