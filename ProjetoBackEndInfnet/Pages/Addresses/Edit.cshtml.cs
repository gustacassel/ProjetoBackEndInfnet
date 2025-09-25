using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Addresses;

public sealed class EditModel : PageModel
{
    [BindProperty]
    public Address Address { get; set; } = default!;
    public SelectList UsersList { get; set; } = null!;

    private readonly IAddressRepository _addressRepository;
    private readonly IUserRepository _userRepository;
    public EditModel(IAddressRepository addressRepository, IUserRepository userRepository)
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

        var address = await _addressRepository.GetByIdAsync(id.Value);

        if (address is null)
        {
            return NotFound();
        }

        Address = address;

        var users = await _userRepository.GetAllAsync();
        UsersList = new SelectList(users, "Id", "Name", Address.UserId);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var users = await _userRepository.GetAllAsync();
            UsersList = new SelectList(users, "Id", "Name", Address?.UserId);
            return Page();
        }

        if (Address is null)
        {
            return NotFound();
        }

        await _addressRepository.UpdateAsync(Address);

        return RedirectToPage("./Index");
    }
}