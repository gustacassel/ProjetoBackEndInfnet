using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Addresses;

public sealed class CreateModel : PageModel
{
    [BindProperty]
    public Address Address { get; set; } = new Address();

    private readonly IAddressRepository _repository;
    public CreateModel(IAddressRepository repository)
    {
        _repository = repository;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _repository.AddAsync(Address);

        return RedirectToPage("./Index");
    }
}