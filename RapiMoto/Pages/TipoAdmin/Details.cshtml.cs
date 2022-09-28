using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_TipoAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DetailsModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

      public TipoAdmin TipoAdmin { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipoAdmin == null)
            {
                return NotFound();
            }

            var tipoadmin = await _context.TipoAdmin.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoadmin == null)
            {
                return NotFound();
            }
            else 
            {
                TipoAdmin = tipoadmin;
            }
            return Page();
        }
    }
}
