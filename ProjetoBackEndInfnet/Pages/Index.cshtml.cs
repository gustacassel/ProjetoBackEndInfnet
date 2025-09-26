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
    public List<int> TopProductsValues { get; set; } = [];

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
        var prods = await _productRepository.GetAllActiveProductsAsync();

        TotalProducts = await _productRepository.GetCountAsync();
        TotalOrders = await _orderRepository.CountAllAsync();
        TotalUsers = await _userRepository.GetCountAsync();
        var pendingOrders = await _orderRepository.GetByStatusAsync(Order.STATUS_PENDING);
        TotalPendingOrders = pendingOrders.Count;

        var topProducts = prods.Take(5).Select(p => new
        {
            p.Description,
            QuantitySold = new Random().Next(1, 100) // Simulando quantidade vendida
        }).ToList();
        TopProductsLabels = topProducts.Select(p => p.Description).ToList();
        TopProductsValues = topProducts.Select(p => p.QuantitySold).ToList();
    }
}
