using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.OrderItems;

public sealed class CreateModel : PageModel
{
    [BindProperty]
    public OrderItem OrderItem { get; set; } = new();

    public long OrderId { get; set; }

    public SelectList ProductsList { get; set; } = null!;

    public IEnumerable<Product> AllProducts { get; set; } = new List<Product>();

    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;

    public CreateModel(IOrderItemRepository orderItemRepository, IProductRepository productRepository)
    {
        _orderItemRepository = orderItemRepository;
        _productRepository = productRepository;
    }

    public async Task<IActionResult> OnGetAsync(long orderId)
    {
        OrderId = orderId;
        OrderItem.OrderId = orderId;

        AllProducts = await _productRepository.GetAllAsync();
        ProductsList = new SelectList(AllProducts, "Id", "Description");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync(OrderItem.OrderId);
            return Page();
        }

        var product = await _productRepository.GetByIdAsync(OrderItem.ProductId);
        if (product == null)
        {
            ModelState.AddModelError("OrderItem.ProductId", "Produto não encontrado.");
            await OnGetAsync(OrderItem.OrderId);
            return Page();
        }

        if (!product.IsInStock(OrderItem.Quantity))
        {
            ModelState.AddModelError("OrderItem.Quantity", $"Quantidade indisponível. Em estoque: {product.QuantityInStock}");
            await OnGetAsync(OrderItem.OrderId);
            return Page();
        }

        OrderItem.UnitPrice = product.Price;

        await _orderItemRepository.AddAsync(OrderItem);

        product.QuantityInStock -= OrderItem.Quantity;
        await _productRepository.UpdateAsync(product);

        return RedirectToPage("./Index", new { orderId = OrderItem.OrderId, message = "create_success" });
    }
}