using System.ComponentModel.DataAnnotations;

namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Programare
    {
        public int? ID { get; set; }

        [Display(Name = "Data Programare")]
        [DataType(DataType.Date)]
        public DateTime? DataProgramare { get; set; }
        public  int? PacientID { get; set; }
        public Pacient? Pacient { get; set; }
        public int? ProceduraID { get; set; }
        public Procedura? Procedura { get; set; }
        public int? MedicID { get; set; }
        public Medic? Medic { get; set; }

    }
}
