using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Pages_Tecnico
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public DetailsModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

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
    }
}
