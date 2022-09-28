using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

using Microsoft.AspNetCore.Authorization;

namespace RapiMoto.Pages_HitorialTecnico
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTecnicoContext _context;

        public IndexModel(RazorPagesTecnicoContext context)
        {
            _context = context;
        }

        public IList<HitorialTecnico> HitorialTecnico { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.HitorialTecnico != null)
            {
                HitorialTecnico = await _context.HitorialTecnico.ToListAsync();
            }
        }
    }
}
