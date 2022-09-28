using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

using Microsoft.AspNetCore.Authorization;

namespace RapiMoto.Pages_HitorialTecnico
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DeleteModel(RazorPagesTecnicoContext context)
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

            var hitorialtecnico = await _context.HitorialTecnico.FirstOrDefaultAsync(m => m.Id == id);

            if (hitorialtecnico == null)
            {
                return NotFound();
            }
            else 
            {
                HitorialTecnico = hitorialtecnico;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.HitorialTecnico == null)
            {
                return NotFound();
            }
            var hitorialtecnico = await _context.HitorialTecnico.FindAsync(id);

            if (hitorialtecnico != null)
            {
                HitorialTecnico = hitorialtecnico;
                _context.HitorialTecnico.Remove(HitorialTecnico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
