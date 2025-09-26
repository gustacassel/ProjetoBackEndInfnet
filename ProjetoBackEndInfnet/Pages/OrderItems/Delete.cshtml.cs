using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.OrderItems;

public sealed class DeleteModel : PageModel
{
    [BindProperty]
    public OrderItem OrderItem { get; set; } = new();

    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;

    public DeleteModel(IOrderItemRepository orderItemRepository, IProductRepository productRepository)
    {
        _orderItemRepository = orderItemRepository;
        _productRepository = productRepository;
    }

    public async Task<IActionResult> OnGetAsync(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var orderItem = await _orderItemRepository.GetByIdAsync(id.Value);

        if (orderItem == null)
        {
            return NotFound();
        }

        OrderItem = orderItem;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(long? id)
    {
        if (id == null) return NotFound();

        var orderItemToDelete = await _orderItemRepository.GetByIdAsync(id.Value);

        if (orderItemToDelete != null)
        {
            var product = await _productRepository.GetByIdAsync(orderItemToDelete.ProductId);

            if (product != null)
            {
                product.QuantityInStock += orderItemToDelete.Quantity;
                await _productRepository.UpdateAsync(product);
            }

            await _orderItemRepository.DeleteAsync(orderItemToDelete.Id);

            return RedirectToPage("./Index", new { orderId = orderItemToDelete.OrderId, message = "delete_success" });
        }

        return NotFound();
    }
}