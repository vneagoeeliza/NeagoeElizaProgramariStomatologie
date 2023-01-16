using System.ComponentModel.DataAnnotations;

namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Procedura
    {
        public int ID { get; set; }
        [Display(Name = "Nume procedura")]
        public string NumeProcedura { get; set; }
        public ICollection<Programare>? Programari { get; set; }

    }
}
