using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NeagoeElizaProgramariStomatologie.Data;
using NeagoeElizaProgramariStomatologie.Models;

namespace NeagoeElizaProgramariStomatologie.Pages.Proceduri
{
    public class DeleteModel : PageModel
    {
        private readonly NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext _context;

        public DeleteModel(NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Procedura Procedura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Procedura == null)
            {
                return NotFound();
            }

            var procedura = await _context.Procedura.FirstOrDefaultAsync(m => m.ID == id);

            if (procedura == null)
            {
                return NotFound();
            }
            else 
            {
                Procedura = procedura;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Procedura == null)
            {
                return NotFound();
            }
            var procedura = await _context.Procedura.FindAsync(id);

            if (procedura != null)
            {
                Procedura = procedura;
                _context.Procedura.Remove(Procedura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
