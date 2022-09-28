using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_Servicio
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public EditModel(RazorPagesTecnicoContext context)
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

            var servicio =  await _context.Servicio.FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }
            Servicio = servicio;
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

            _context.Attach(Servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(Servicio.Id))
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

        private bool ServicioExists(int id)
        {
          return (_context.Servicio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
