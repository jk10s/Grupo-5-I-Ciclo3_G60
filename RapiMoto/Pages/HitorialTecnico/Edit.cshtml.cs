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

namespace RapiMoto.Pages_HitorialTecnico
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
        public HitorialTecnico HitorialTecnico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HitorialTecnico == null)
            {
                return NotFound();
            }

            var hitorialtecnico =  await _context.HitorialTecnico.FirstOrDefaultAsync(m => m.Id == id);
            if (hitorialtecnico == null)
            {
                return NotFound();
            }
            HitorialTecnico = hitorialtecnico;
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

            _context.Attach(HitorialTecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HitorialTecnicoExists(HitorialTecnico.Id))
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

        private bool HitorialTecnicoExists(int id)
        {
          return (_context.HitorialTecnico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
