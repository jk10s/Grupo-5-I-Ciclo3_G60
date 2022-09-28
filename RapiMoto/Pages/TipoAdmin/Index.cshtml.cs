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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public IndexModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

        public IList<TipoAdmin> TipoAdmin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TipoAdmin != null)
            {
                TipoAdmin = await _context.TipoAdmin.ToListAsync();
            }
        }
    }
}
