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
    public class CreateModel : SpecializariMedicPageModel
    {
        private readonly NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext _context;

        public CreateModel(NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var medic = new Medic();
            medic.SpecializariMedic = new List<SpecializareMedic>();
            PopulateAssignedSpecializareData(_context, medic);
            return Page();
        }

        [BindProperty]
        public Medic Medic { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] specializariSelectate)
        {
            var medicNou = new Medic();
            if (specializariSelectate != null)
            {
                medicNou.SpecializariMedic = new List<SpecializareMedic>();
                foreach (var specializare in specializariSelectate)
                {
                    var specializareAdaugata = new SpecializareMedic
                    {
                        SpecializareID = int.Parse(specializare)
                    };
                    medicNou.SpecializariMedic.Add(specializareAdaugata);
                }
            }
            if (await TryUpdateModelAsync<Medic>(
            medicNou,
            "Medic",
            i => i.NumeMedic, i => i.PrenumeMedic))
            {
                _context.Medic.Add(medicNou);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedSpecializareData(_context, medicNou);
            return Page();
        }
    }
}
