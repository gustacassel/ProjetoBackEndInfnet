using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Orders;

public sealed class CreateModel : PageModel
{
    [BindProperty]
    public Order Order { get; set; } = new();
    public SelectList UsersList { get; set; } = null!;

    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAddressRepository _addressRepository;
    public CreateModel(
        IOrderRepository orderRepository,
        IUserRepository userRepository,
        IAddressRepository addressRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _addressRepository = addressRepository;
    }

    public async Task OnGetAsync()
    {
        var users = await _userRepository.GetAllAsync();
        UsersList = new SelectList(users, "Id", "Name");
    }

    public async Task<IActionResult> OnGetAddressesAsync(long userId)
    {
        var addresses = await _addressRepository.GetByUserIdAsync(userId);

        var addressData = addresses.Select(a => new
        {
            id = a.Id,
            text = $"{a.Street}, {a.City}"
        }).ToList();

        return new JsonResult(addressData);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync();
            return Page();
        }

        await _orderRepository.AddAsync(Order);

        return RedirectToPage("../OrderItems/Index", new { orderId = Order.Id });
    }
}