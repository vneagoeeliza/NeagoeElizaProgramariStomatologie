using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NeagoeElizaProgramariStomatologie.Data;
using NeagoeElizaProgramariStomatologie.Models;

namespace NeagoeElizaProgramariStomatologie.Pages.Specializari
{
    public class IndexModel : PageModel
    {
        private readonly NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext _context;

        public IndexModel(NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext context)
        {
            _context = context;
        }

        public IList<Specializare> Specializare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Specializare != null)
            {
                Specializare = await _context.Specializare.ToListAsync();
            }
        }
    }
}
