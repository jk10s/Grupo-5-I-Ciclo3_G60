using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_Servicio
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DetailsModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

      public Servicio Servicio { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Servicio == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicio.FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }
            else 
            {
                Servicio = servicio;
            }
            return Page();
        }
    }
}
