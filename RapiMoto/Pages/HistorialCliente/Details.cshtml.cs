using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_HistorialCliente
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DetailsModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

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
    }
}
