using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

using Microsoft.AspNetCore.Authorization;

namespace RapiMoto.Pages_Tecnico
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
      public Tecnico Tecnico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tecnico == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnico.FirstOrDefaultAsync(m => m.Id == id);

            if (tecnico == null)
            {
                return NotFound();
            }
            else 
            {
                Tecnico = tecnico;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tecnico == null)
            {
                return NotFound();
            }
            var tecnico = await _context.Tecnico.FindAsync(id);

            if (tecnico != null)
            {
                Tecnico = tecnico;
                _context.Tecnico.Remove(Tecnico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
