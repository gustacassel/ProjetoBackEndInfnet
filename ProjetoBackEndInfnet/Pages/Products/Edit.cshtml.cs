using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Products;

public sealed class EditModel : PageModel
{
    [BindProperty]
    public Product? Product { get; set; }

    private readonly IProductRepository _repository;
    public EditModel(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync(long? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        Product = await _repository.GetByIdAsync(id.Value);

        if (Product is null)
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

        if (Product is null)
        {
            return NotFound();
        }

        await _repository.UpdateAsync(Product!);

        return RedirectToPage("./Index");
    }
}