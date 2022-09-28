using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_Servicio
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DeleteModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Servicio Servicio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Servicio == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicio.FirstOrDefaultAsync(m => m.Id == id);

            if (servicio == null)
            {
                return NotFound();
            }
            else 
            {
                Servicio = servicio;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Servicio == null)
            {
                return NotFound();
            }
            var servicio = await _context.Servicio.FindAsync(id);

            if (servicio != null)
            {
                Servicio = servicio;
                _context.Servicio.Remove(Servicio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
