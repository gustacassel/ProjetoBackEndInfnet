using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Users;

public sealed class EditModel : PageModel
{
    [BindProperty]
    public new User? User { get; set; }

    private readonly IUserRepository _repository;
    public EditModel(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync(long? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        User = await _repository.GetByIdAsync(id.Value);
        if (User is null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (User is null)
        {
            return Page();
        }

        await _repository.UpdateAsync(User);

        return RedirectToPage("./Index");
    }
}