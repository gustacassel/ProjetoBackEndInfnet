using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.OrderItems;

public sealed class IndexModel : PageModel
{
    public long OrderId { get; set; }

    public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IOrderRepository _orderRepository;

    public IndexModel(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository)
    {
        _orderItemRepository = orderItemRepository;
        _orderRepository = orderRepository;
    }

    public async Task<IActionResult> OnGetAsync(long? orderId)
    {
        if (orderId == null)
        {
            return NotFound();
        }

        var order = await _orderRepository.GetByIdAsync(orderId.Value);
        if (order == null)
        {
            return NotFound();
        }

        OrderId = orderId.Value;
        OrderItems = await _orderItemRepository.GetByOrderIdAsync(orderId.Value);

        return Page();
    }
}