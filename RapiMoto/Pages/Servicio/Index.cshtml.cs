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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public IndexModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

        public IList<Servicio> Servicio { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Servicio != null)
            {
                Servicio = await _context.Servicio.ToListAsync();
            }
        }
    }
}
