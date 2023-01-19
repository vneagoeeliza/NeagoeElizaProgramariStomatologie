using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using NeagoeElizaProgramariStomatologie.Data;
using NeagoeElizaProgramariStomatologie.Migrations;
using NeagoeElizaProgramariStomatologie.Models;
using Medic = NeagoeElizaProgramariStomatologie.Models.Medic;

namespace NeagoeElizaProgramariStomatologie.Pages.Medici
{
    [Authorize(Roles = "Admin")]

    public class EditModel : SpecializariMedicPageModel
    {
        private readonly NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext _context;

        public EditModel(NeagoeElizaProgramariStomatologie.Data.NeagoeElizaProgramariStomatologieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medic Medic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Medic == null)
            {
                return NotFound();
            }

            Medic =  await _context.Medic
                .Include(b=>b.SpecializariMedic)
                .ThenInclude(b=>b.Specializare)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Medic == null)
            {
                return NotFound();
            }
          //  Medic = medic;
            PopulateAssignedSpecializareData(_context, Medic);

 
           ViewData["SpecializareID"] = new SelectList(_context.Specializare, "ID", "NumeSpecializare");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int?id, string[] specializariSelectate)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medicEditat = await _context.Medic
                            .Include(i => i.SpecializariMedic)
                            .ThenInclude(i => i.Specializare)
                            .FirstOrDefaultAsync(s => s.ID == id);
            if (medicEditat == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Medic>(
            medicEditat,
            "Medic",
            i => i.NumeMedic, i => i.PrenumeMedic))
            {
                UpdateSpecializariMedic(_context, specializariSelectate, medicEditat);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateSpecializariMedic(_context, specializariSelectate, medicEditat);
            PopulateAssignedSpecializareData(_context, medicEditat);
            return Page();
        }

        private bool MedicExists(int? id)
        {
          return (_context.Medic?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
