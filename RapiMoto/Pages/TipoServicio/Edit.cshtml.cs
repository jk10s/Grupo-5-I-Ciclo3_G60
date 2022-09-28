using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

using Microsoft.AspNetCore.Authorization;

namespace RapiMoto.Pages_TipoServicio
{
    [Authorize]
    public class EditModel : PageModel
    {
        
        private readonly RazorPagesTecnicoContext _context;

        public EditModel(RazorPagesTecnicoContext context)
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

            var tiposervicio =  await _context.TipoServicio.FirstOrDefaultAsync(m => m.Id == id);
            if (tiposervicio == null)
            {
                return NotFound();
            }
            TipoServicio = tiposervicio;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TipoServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoServicioExists(TipoServicio.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TipoServicioExists(int id)
        {
          return (_context.TipoServicio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
