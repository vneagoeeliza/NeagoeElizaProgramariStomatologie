using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NeagoeElizaProgramariStomatologie.Data;
using NeagoeElizaProgramariStomatologie.Models;

namespace NeagoeElizaProgramariStomatologie.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext _context;

        public IndexModel(NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get; set; } = default!;
        public ProgramariData ProgramariD { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            ProgramariD = new ProgramariData();
            CurrentFilter = searchString;

            if (_context.Programare != null)
            {
                ProgramariD.Programari = await _context.Programare
                .Include(p => p.Medic)
                .Include(p => p.Pacient)
                .Include(p => p.Procedura).ToListAsync();
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                ProgramariD.Programari = ProgramariD.Programari.Where(s => s.Pacient.NumePacient.Contains(searchString)

               || s.Pacient.PrenumePacient.Contains(searchString));


            }
        }
    }
}
