using System.ComponentModel.DataAnnotations;

namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Pacient
    {
        public int ID { get; set; }
        [Display(Name = "Prenume")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prenumele pacientului trebuie sa fie de forma 'Prenume'"),
          StringLength(50, MinimumLength = 3)]
    
        public string? PrenumePacient { get; set; }
        [Display(Name = "Nume")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele pacientului trebuie sa fie de forma 'Nume'"),
         StringLength(50, MinimumLength = 3)]
        public string? NumePacient { get; set; }
        [Display(Name = "Telefon Pacient")]
        public string? TelefonPacient { get; set; }
        [Display(Name = "Email Pacient")]

        public string? EmailPacient { get; set; }
        public ICollection<Programare>? Programari { get; set; }
        [Display(Name = "Nume Pacient")]
        public string FullName
        {
            get
            {
                return PrenumePacient + " " + NumePacient;
            }
        }

    }
}
