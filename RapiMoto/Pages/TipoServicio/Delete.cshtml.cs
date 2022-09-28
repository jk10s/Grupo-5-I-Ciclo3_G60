using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_TipoServicio
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DeleteModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TipoServicio TipoServicio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipoServicio == null)
            {
                return NotFound();
            }

            var tiposervicio = await _context.TipoServicio.FirstOrDefaultAsync(m => m.Id == id);

            if (tiposervicio == null)
            {
                return NotFound();
            }
            else 
            {
                TipoServicio = tiposervicio;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TipoServicio == null)
            {
                return NotFound();
            }
            var tiposervicio = await _context.TipoServicio.FindAsync(id);

            if (tiposervicio != null)
            {
                TipoServicio = tiposervicio;
                _context.TipoServicio.Remove(TipoServicio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
