using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeagoeElizaProgramariStomatologie.Data;
using NeagoeElizaProgramariStomatologie.Models;

namespace NeagoeElizaProgramariStomatologie.Pages.Medici
{
    public class CreateModel : PageModel
    {
        private readonly NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext _context;

        public CreateModel(NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SpecializareID"] = new SelectList(_context.Specializare, "ID", "NumeSpecializare");
            return Page();
        }

        [BindProperty]
        public Medic Medic { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Medic == null || Medic == null)
            {
                return Page();
            }

            _context.Medic.Add(Medic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
