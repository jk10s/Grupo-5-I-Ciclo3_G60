using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_Tecnico
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public EditModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tecnico Tecnico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tecnico == null)
            {
                return NotFound();
            }

            var tecnico =  await _context.Tecnico.FirstOrDefaultAsync(m => m.Id == id);
            if (tecnico == null)
            {
                return NotFound();
            }
            Tecnico = tecnico;
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

            _context.Attach(Tecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoExists(Tecnico.Id))
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

        private bool TecnicoExists(int id)
        {
          return (_context.Tecnico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
