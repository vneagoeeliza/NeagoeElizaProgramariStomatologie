using System.Security.Policy;

namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Medic
    {
        public int? ID { get; set; }
        public string? PrenumeMedic { get; set; }
        public string? NumeMedic { get; set; }
        public int? SpecializareID { get; set; }
        public Specializare? Specializare { get; set; }
        public ICollection<Programare>? Programari { get; set; }
    }
}
