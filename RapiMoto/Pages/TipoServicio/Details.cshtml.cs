using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_TipoServicio
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DetailsModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

      public TipoServicio TipoServicio { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipoServicio == null)
            {
                return NotFound();
            }

            var tiposervicio = await _context.TipoServicio.FirstOrDefaultAsync(m => m.Id == id);
            if (tiposervicio == null)
            {
                return NotFound();
            }
            else 
            {
                TipoServicio = tiposervicio;
            }
            return Page();
        }
    }
}
