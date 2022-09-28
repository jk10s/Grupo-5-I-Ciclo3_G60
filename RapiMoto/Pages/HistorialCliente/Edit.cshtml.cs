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

namespace RapiMoto.Pages_HistorialCliente
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
        public HistorialCliente HistorialCliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HistorialCliente == null)
            {
                return NotFound();
            }

            var historialcliente =  await _context.HistorialCliente.FirstOrDefaultAsync(m => m.Id == id);
            if (historialcliente == null)
            {
                return NotFound();
            }
            HistorialCliente = historialcliente;
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

            _context.Attach(HistorialCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialClienteExists(HistorialCliente.Id))
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

        private bool HistorialClienteExists(int id)
        {
          return (_context.HistorialCliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
