using System.Security.Policy;

namespace NeagoeElizaProgramariStomatologie.Models.ViewModels
{
    public class SpecializareIndexData
    {
        public IEnumerable<Specializare>? Specializari { get; set; }
        public IEnumerable<SpecializareMedic> SpecializariMedici { get; set; }
        public IEnumerable<Medic>? Medici { get; set; }

    }
}
