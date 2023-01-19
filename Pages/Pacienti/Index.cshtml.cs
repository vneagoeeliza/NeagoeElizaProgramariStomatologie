using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NeagoeElizaProgramariStomatologie.Data;
using NeagoeElizaProgramariStomatologie.Models;

namespace NeagoeElizaProgramariStomatologie.Pages.Pacienti
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext _context;

        public IndexModel(NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext context)
        {
            _context = context;
        }

        public IList<Pacient> Pacient { get; set; } = default!;
        public PacientData PacientD { get; set; }
        public int PacientID { get; set; }
        public string NumeSort { get; set; }
        public string PrenumeSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString, string sortOrder)
        {
            PacientD = new PacientData();
            CurrentFilter = searchString;
            NumeSort = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            PrenumeSort = String.IsNullOrEmpty(sortOrder) ? "prenume_desc" : "";
            {
                if (_context.Pacient != null)
                {
                    PacientD.Pacienti = await _context.Pacient.
                        ToListAsync();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        PacientD.Pacienti = PacientD.Pacienti.Where(s => s.NumePacient.Contains(searchString)

                       || s.PrenumePacient.Contains(searchString));
                    }
                    switch (sortOrder)
                    {
                        case "nume_desc":
                            PacientD.Pacienti = PacientD.Pacienti.OrderByDescending(s =>
                           s.NumePacient);
                            break;
                        case "prenume_desc":
                            PacientD.Pacienti = PacientD.Pacienti.OrderByDescending(s =>
                         s.PrenumePacient);
                            break;

                    }
                }
            }
        }
    }
}
