using System.ComponentModel.DataAnnotations;

namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Specializare
    {
        public int ID { get; set; }
        [Display(Name = "Nume specializare")]
        public string NumeSpecializare { get; set; }
        public ICollection<Medic>? Medici { get; set; }
    }
}
