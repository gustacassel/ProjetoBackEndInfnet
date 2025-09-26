using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages;

public sealed class IndexModel : PageModel
{
    public int TotalProducts { get; set; }
    public int TotalOrders { get; set; }
    public int TotalPendingOrders { get; set; }
    public int TotalUsers { get; set; }

    public List<string> TopProductsLabels { get; set; } = [];
    public List<decimal> TopProductsValues { get; set; } = [];

    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    public IndexModel(IProductRepository productRepository, IOrderRepository orderRepository, IUserRepository userRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }

    public async Task OnGetAsync()
    {
        TotalProducts = await _productRepository.GetCountAsync();
        TotalOrders = await _orderRepository.CountAllAsync();
        TotalUsers = await _userRepository.GetCountAsync();

        var pendingOrders = await _orderRepository.GetByStatusAsync(Order.STATUS_PENDING);
        TotalPendingOrders = pendingOrders.Count;

        var prods = await _productRepository.GetAllActiveProductsAsync();

        var topProducts = prods
            .Select(p => new
            {
                p.Description,
                QuantitySold = p.OrderItems.Sum(oi => oi.Quantity)
            })
            .Where(p => p.QuantitySold > 0)
            .OrderByDescending(p => p.QuantitySold)
            .Take(5)
            .ToList();

        TopProductsLabels = topProducts.Select(p => p.Description).ToList();
        TopProductsValues = topProducts.Select(p => p.QuantitySold).ToList();
    }
}