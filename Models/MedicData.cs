namespace NeagoeElizaProgramariStomatologie.Models
{
    public class MedicData
    {
        public IEnumerable<Medic> Medici { get; set; }
        public IEnumerable<Specializare> Specializari { get; set; }
        public IEnumerable<SpecializareMedic> SpecializariMedici { get; set; }
    }
}
