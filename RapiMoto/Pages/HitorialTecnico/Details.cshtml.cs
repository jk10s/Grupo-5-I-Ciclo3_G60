using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_HitorialTecnico
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DetailsModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

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
    }
}
