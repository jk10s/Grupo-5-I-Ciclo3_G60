using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_Administrador
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DeleteModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Administrador Administrador { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Administrador == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador.FirstOrDefaultAsync(m => m.Id == id);

            if (administrador == null)
            {
                return NotFound();
            }
            else 
            {
                Administrador = administrador;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Administrador == null)
            {
                return NotFound();
            }
            var administrador = await _context.Administrador.FindAsync(id);

            if (administrador != null)
            {
                Administrador = administrador;
                _context.Administrador.Remove(Administrador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
