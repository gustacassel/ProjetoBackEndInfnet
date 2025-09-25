using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Addresses;

public sealed class DeleteModel : PageModel
{
    [BindProperty]
    public Address? Address { get; set; }
    public string? UserName { get; set; }

    private readonly IAddressRepository _addressRepository;
    private readonly IUserRepository _userRepository;

    public DeleteModel(IAddressRepository addressRepository, IUserRepository userRepository)
    {
        _addressRepository = addressRepository;
        _userRepository = userRepository;
    }

    public async Task<IActionResult> OnGetAsync(long? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        Address = await _addressRepository.GetByIdAsync(id.Value);

        if (Address is null)
        {
            return NotFound();
        }

        var user = await _userRepository.GetByIdAsync(Address.UserId);
        UserName = user?.Name;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(long? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        await _addressRepository.DeleteAsync(id.Value);

        return RedirectToPage("./Index");
    }
}
