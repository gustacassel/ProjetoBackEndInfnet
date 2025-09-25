using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Addresses;

public sealed class CreateModel : PageModel
{
    [BindProperty]
    public Address Address { get; set; } = new Address();
    public SelectList? UsersList { get; set; }
    public User? Usuario { get; set; }

    private readonly IAddressRepository _addressRepository;
    private readonly IUserRepository _userRepository;

    public CreateModel(IAddressRepository addressRepository, IUserRepository userRepository)
    {
        _addressRepository = addressRepository;
        _userRepository = userRepository;
    }

    public async Task<IActionResult> OnGetAsync(long? userId)
    {
        if (userId.HasValue)
        {
            Usuario = await _userRepository.GetByIdAsync(userId.Value);
            if (Usuario is null)
            {
                return NotFound();
            }

            Address.UserId = Usuario.Id; // já amarra o usuário
        }
        else
        {
            var users = await _userRepository.GetAllAsync();
            UsersList = new SelectList(users, "Id", "Name");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            if (Usuario is null)
            {
                var users = await _userRepository.GetAllAsync();
                UsersList = new SelectList(users, "Id", "Name");
            }
            return Page();
        }

        await _addressRepository.AddAsync(Address);
        return RedirectToPage("./Index", new { userId = Address.UserId });
    }
}
