using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoBackEndInfnet.Data;
using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ProjetoBackEndInfnet.Data.AppDbContext _context;

        public DetailsModel(ProjetoBackEndInfnet.Data.AppDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}
