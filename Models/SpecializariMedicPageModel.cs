using Microsoft.AspNetCore.Mvc.RazorPages;
using NeagoeElizaProgramariStomatologie.Data;
namespace NeagoeElizaProgramariStomatologie.Models
{
    public class SpecializariMedicPageModel :PageModel
    {
        public List<AssignedSpecializareData> AssignedSpecializareDataList;
        public void PopulateAssignedSpecializareData(NeagoeElizaProgramariStomatologieContext context,
        Medic medic)
        {
            var toateSpecializarile = context.Specializare;
            var specializariMedic = new HashSet<int>(medic.SpecializariMedic.Select(c => c.SpecializareID)); 
            AssignedSpecializareDataList = new List<AssignedSpecializareData>();
            foreach (var specializare in toateSpecializarile)
            {
                AssignedSpecializareDataList.Add(new AssignedSpecializareData
                {
                    SpecializareID = specializare.ID,
                    Nume = specializare.NumeSpecializare,
                    Assigned = specializariMedic.Contains(specializare.ID)
                });
            }
        }
        public void UpdateSpecializariMedic(NeagoeElizaProgramariStomatologieContext context,
        string[] specializariSelectate, Medic medicEditat)
        {
            if (specializariSelectate == null)
            {
                medicEditat.SpecializariMedic = new List<SpecializareMedic>();
                return;
            }
            var specializariSelectateSH = new HashSet<string>(specializariSelectate);
            var specializariMedic = new HashSet<int>
            (medicEditat.SpecializariMedic.Select(c => c.Specializare.ID));
            
            foreach (var specializare in context.Specializare)
            {
                if (specializariSelectateSH.Contains(specializare.ID.ToString()))
                {
                    if (!specializariMedic.Contains(specializare.ID))
                    {
                        medicEditat.SpecializariMedic.Add(
                        new SpecializareMedic
                        {
                            MedicID = medicEditat.ID,
                            SpecializareID = specializare.ID
                        });
                    }
                }
                else
                {
                    if (specializariMedic.Contains(specializare.ID))
                    {
                        SpecializareMedic courseToRemove
                        = medicEditat
                        .SpecializariMedic
                        .SingleOrDefault(i => i.SpecializareID == specializare.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
