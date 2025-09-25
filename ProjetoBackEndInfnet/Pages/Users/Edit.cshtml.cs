using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Users;

public sealed class EditModel : PageModel
{
    [BindProperty]
    public new User User { get; set; } = null!;

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

        var user = await _repository.GetByIdAsync(id.Value);
        if (user is null)
        {
            return NotFound();
        }

        User = user;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Remove o erro de senha do ModelState
        var userPasswordKey = nameof(User) + "." + nameof(User.Password);
        ModelState.Remove(userPasswordKey);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _repository.UpdateAsync(User);

        return RedirectToPage("./Index");
    }
}