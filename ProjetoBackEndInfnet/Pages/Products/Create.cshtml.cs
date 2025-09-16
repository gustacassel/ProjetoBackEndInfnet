using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Products;

public sealed class CreateModel : PageModel
{
    [BindProperty]
    public Product? Product { get; set; }

    private readonly IProductRepository _repository;
    public CreateModel(IProductRepository repository)
    {
        _repository = repository;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || Product == null)
        {
            return Page();
        }

        await _repository.AddAsync(Product);

        return RedirectToPage("./Index");
    }
}