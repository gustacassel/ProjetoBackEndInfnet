using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoBackEndInfnet.Models;
using ProjetoBackEndInfnet.Repositories;

namespace ProjetoBackEndInfnet.Pages.Addresses;

public sealed class IndexModel : PageModel
{
    public List<Address> Addresses { get; set; } = [];
    public User? Usuario { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? UserId { get; set; }

    private readonly IAddressRepository _addressRepository;
    private readonly IUserRepository _userRepository;
    public IndexModel(IAddressRepository addressRepository, IUserRepository userRepository)
    {
        _addressRepository = addressRepository;
        _userRepository = userRepository;
    }

    public async Task OnGetAsync()
    {
        if (UserId.HasValue)
        {
            Usuario = await _userRepository.GetByIdAsync(UserId.Value);
            Addresses = await _addressRepository.GetByUserIdAsync(UserId.Value);
        }
        else
        {
            Addresses = await _addressRepository.GetAllAsync();
        }
    }
}