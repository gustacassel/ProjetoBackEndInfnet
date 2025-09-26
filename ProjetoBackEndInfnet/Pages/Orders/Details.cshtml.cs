using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoBackEndInfnet.Data;
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

        // Busca o pedido e usa Include para carregar os dados relacionados
        var order = await _orderRepository
            .GetByIdAsync(id.Value);

        if (order == null)
        {
            return NotFound();
        }

        Order = order;

        return Page();
    }
}