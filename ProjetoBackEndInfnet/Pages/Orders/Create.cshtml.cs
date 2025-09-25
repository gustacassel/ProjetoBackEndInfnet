using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Orders;

public sealed class CreateModel : PageModel
{
    [BindProperty]
    public Order Order { get; set; } = new Order();

    [BindProperty]
    public List<OrderItem> OrderItems { get; set; } = [];

    public SelectList UsersList { get; set; } = null!;
    public List<Product> ProductsList { get; set; } = [];
    public SelectList AddressesList { get; set; } = null!;

    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IProductRepository _productRepository;

    public CreateModel(IOrderRepository orderRepository, IUserRepository userRepository,
        IAddressRepository addressRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _addressRepository = addressRepository;
        _productRepository = productRepository;
    }

    public async Task OnGetAsync()
    {
        var users = await _userRepository.GetAllAsync();
        UsersList = new SelectList(users, nameof(Models.User.Id), nameof(Models.User.Name));

        ProductsList = await _productRepository.GetAllAsync();

        var addresses = await _addressRepository.GetAllAsync();
        AddressesList = new SelectList(addresses, nameof(Models.Address.Id), nameof(Models.Address.Street));
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync();
            return Page();
        }

        Order.OrderItems = OrderItems;
        await _orderRepository.AddAsync(Order);

        return RedirectToPage("./Index");
    }
}
