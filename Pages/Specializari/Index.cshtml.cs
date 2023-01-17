using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NeagoeElizaProgramariStomatologie.Data;
using NeagoeElizaProgramariStomatologie.Models;
using NeagoeElizaProgramariStomatologie.Models.ViewModels;

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
        public SpecializareIndexData SpecializareData { get; set; }
        public int SpecializareID { get; set; }
        public int MedicID { get; set; }

        public async Task OnGetAsync(int? id, int? medicID)
        {
            SpecializareData = new SpecializareIndexData();
            SpecializareData.Specializari = await _context.Specializare
            .Include(i => i.Medici)
              
            .OrderBy(i => i.NumeSpecializare)
            .ToListAsync();
            if (id != null)
            {
                SpecializareID = id.Value;
                Specializare specializare = SpecializareData.Specializari
                .Where(i => i.ID == id.Value).Single();
                SpecializareData.Medici = specializare.Medici;
            }
        }
    }
}
