using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages;

public class DashboardModel : PageModel
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;

    public int TotalProducts { get; set; }
    public int TotalOrders { get; set; }
    public int TotalUsers { get; set; }
    public int PendingOrders { get; set; }

    public DashboardModel(
        IProductRepository productRepository,
        IOrderRepository orderRepository,
        IUserRepository userRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }

    public async Task OnGetAsync()
    {
        TotalProducts = (await _productRepository.GetAllAsync()).Count;
        //TotalOrders = (await _orderRepository.GetAllAsync()).Count;
        //TotalUsers = (await _userRepository.GetAllAsync()).Count;
        //PendingOrders = (await _orderRepository.GetPendingOrdersAsync()).Count;

        // valores falsos temporários
        TotalOrders = 10;
        TotalUsers = 5;
        PendingOrders = 2;
    }
}