using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RapiMoto.Models;

using Microsoft.AspNetCore.Authorization;

namespace RapiMoto.Pages_HistorialCliente
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public CreateModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HistorialCliente HistorialCliente { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.HistorialCliente == null || HistorialCliente == null)
            {
                return Page();
            }

            _context.HistorialCliente.Add(HistorialCliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
