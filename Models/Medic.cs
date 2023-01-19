using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Medic
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prenumele autorului trebuie sa fie de forma 'Prenume'"),
            Required, StringLength(50,MinimumLength = 3)]

        [Display(Name = "Prenume medic")]
        public string? PrenumeMedic { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Nume autorului trebuie sa fie de forma 'Nume'"),
            Required, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nume medic")]
          public string? NumeMedic { get; set; }
        public ICollection<Programare>? Programari { get; set; }
        [Display(Name = "Specializare medic")]
        public ICollection<SpecializareMedic>? SpecializariMedic { get; set; }
        [Display(Name = "Nume Medic")]
        public string FullName
        {
            get
            {
                return PrenumeMedic + " " + NumeMedic;
            }
        }
    }
}
