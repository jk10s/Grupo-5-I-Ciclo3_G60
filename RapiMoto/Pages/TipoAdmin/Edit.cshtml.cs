using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_TipoAdmin
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public EditModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoAdmin TipoAdmin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipoAdmin == null)
            {
                return NotFound();
            }

            var tipoadmin =  await _context.TipoAdmin.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoadmin == null)
            {
                return NotFound();
            }
            TipoAdmin = tipoadmin;
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

            _context.Attach(TipoAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoAdminExists(TipoAdmin.Id))
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

        private bool TipoAdminExists(int id)
        {
          return (_context.TipoAdmin?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
