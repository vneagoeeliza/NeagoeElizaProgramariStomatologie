using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Medic
    {
        public int? ID { get; set; }
        [Display(Name = "Prenume medic")]

        public string? PrenumeMedic { get; set; }
        [Display(Name = "Nume medic")]

        public string? NumeMedic { get; set; }
        public int? SpecializareID { get; set; }
        public Specializare? Specializare { get; set; }
        public ICollection<Programare>? Programari { get; set; }
        [Display(Name = "Nume")]
        public string FullName
        {
            get
            {
                return PrenumeMedic + " " + NumeMedic;
            }
        }
    }
}
