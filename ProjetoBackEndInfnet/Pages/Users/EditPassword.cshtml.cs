using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Users;

public sealed class EditPasswordModel : PageModel
{
    [BindProperty]
    public PasswordChangeModel PasswordChange { get; set; } = new PasswordChangeModel();
    public long UserId { get; set; }

    private readonly IUserRepository _repository;
    public EditPasswordModel(IUserRepository repository)
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

        UserId = user.Id;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(long id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _repository.GetByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        // verifica senha atual
        if (user.Password != PasswordChange.CurrentPassword)
        {
            ModelState.AddModelError("PasswordChange.CurrentPassword", "Senha atual incorreta.");
            return Page();
        }

        // verifica se nova senha confere
        if (PasswordChange.NewPassword != PasswordChange.ConfirmPassword)
        {
            ModelState.AddModelError("PasswordChange.ConfirmPassword", "As senhas n�o coincidem.");
            return Page();
        }

        // atualiza senha
        user.Password = PasswordChange.NewPassword;
        await _repository.UpdateAsync(user);

        return RedirectToPage("./Index");
    }

    public sealed class PasswordChangeModel
    {
        [Display(Name = "Senha Atual")]
        [Required(ErrorMessage = "A senha atual � obrigat�ria.")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Display(Name = "Nova Senha")]
        [Required(ErrorMessage = "A nova senha � obrigat�ria.")]
        public string NewPassword { get; set; } = string.Empty;

        [Display(Name = "Confirmar Nova Senha")]
        [Required(ErrorMessage = "A confirma��o da nova senha � obrigat�ria.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}