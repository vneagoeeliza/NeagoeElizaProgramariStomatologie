using System.ComponentModel.DataAnnotations;

namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Pacient
    {
        public int ID { get; set; }
        [Display(Name = "Prenume")]
        public string PrenumePacient { get; set; }
        [Display(Name = "Nume")]
        public string NumePacient { get; set; }
        [Display(Name = "Telefon")]
        public string TelefonPacient { get; set; }
        public ICollection<Programare>? Programari { get; set; }
        [Display(Name = "Nume")]
        public string FullName
        {
            get
            {
                return PrenumePacient + " " + NumePacient;
            }
        }
    }
}
