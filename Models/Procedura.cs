namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Procedura
    {
        public int ID { get; set; }
        public string NumeProcedura { get; set; }
        public ICollection<Programare>? Programari { get; set; }

    }
}
