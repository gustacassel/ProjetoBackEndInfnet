using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Users;

public sealed class CreateModel : PageModel
{
    [BindProperty]
    public new User? User { get; set; }

    private readonly IUserRepository _repository;
    public CreateModel(IUserRepository repository)
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

        if (User is null)
        {
            return Page();
        }

        await _repository.AddAsync(User);

        return RedirectToPage("./Index");
    }
}