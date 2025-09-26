using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Orders;

public sealed class DeleteModel : PageModel
{
    [BindProperty]
    public Order Order { get; set; } = new();

    private readonly IOrderRepository _orderRepository;
    public DeleteModel(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IActionResult> OnGetAsync(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Busca o pedido com os dados de usuário e endereço
        var order = await _orderRepository.GetByIdAsync(id.Value);

        if (order == null)
        {
            return NotFound();
        }

        Order = order;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var orderToDelete = await _orderRepository.GetByIdAsync(id.Value);

        if (orderToDelete != null)
        {
            await _orderRepository.DeleteAsync(orderToDelete.Id);
            TempData["Message"] = "Pedido excluído com sucesso!";
        }

        return RedirectToPage("./Index");
    }
}