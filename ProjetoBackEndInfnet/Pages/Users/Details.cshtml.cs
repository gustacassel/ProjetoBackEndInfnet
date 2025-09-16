using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Users;

public sealed class DetailsModel : PageModel
{
    public new User User { get; set; } = null!;

    private readonly IUserRepository _repository;
    public DetailsModel(IUserRepository repository)
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
}