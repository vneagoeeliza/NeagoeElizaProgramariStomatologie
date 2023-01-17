using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NeagoeElizaProgramariStomatologie.Data;
using NeagoeElizaProgramariStomatologie.Models;

namespace NeagoeElizaProgramariStomatologie.Pages.Medici
{
    public class IndexModel : PageModel
    {
        private readonly NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext _context;

        public IndexModel(NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext context)
        {
            _context = context;
        }

        public IList<Medic> Medic { get;set; } = default!;
        public MedicData MedicD { get; set; }
        public int MedicID { get; set; }
        public int SpecializareID { get; set; }


        public async Task OnGetAsync(int? id, int? specializareID)
        {
            MedicD = new MedicData();
            MedicD.Medici = await _context.Medic
                .Include(b => b.SpecializariMedic)
                .ThenInclude(b => b.Specializare)
                .AsNoTracking()
                .OrderBy(b => b.PrenumeMedic)
                .ToListAsync();
            if (id != null)
            {
                MedicID = id.Value;
                Medic medic = MedicD.Medici
                    .Where(i=>i.ID == id.Value).Single();
                MedicD.Specializari = medic.SpecializariMedic.Select(s => s.Specializare);
            }
        }
    }
}
