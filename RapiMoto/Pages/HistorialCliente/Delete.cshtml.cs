using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

using Microsoft.AspNetCore.Authorization;

namespace RapiMoto.Pages_HistorialCliente
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
      public HistorialCliente HistorialCliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HistorialCliente == null)
            {
                return NotFound();
            }

            var historialcliente = await _context.HistorialCliente.FirstOrDefaultAsync(m => m.Id == id);

            if (historialcliente == null)
            {
                return NotFound();
            }
            else 
            {
                HistorialCliente = historialcliente;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.HistorialCliente == null)
            {
                return NotFound();
            }
            var historialcliente = await _context.HistorialCliente.FindAsync(id);

            if (historialcliente != null)
            {
                HistorialCliente = historialcliente;
                _context.HistorialCliente.Remove(HistorialCliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
