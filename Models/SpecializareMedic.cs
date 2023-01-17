namespace NeagoeElizaProgramariStomatologie.Models
{
    public class SpecializareMedic
    {
        public int ID { get; set; }
        public int MedicID { get; set; }
        public Medic? Medic { get; set; }
        public int SpecializareID { get; set; }
        public Specializare? Specializare { get; set; }
    }
}
