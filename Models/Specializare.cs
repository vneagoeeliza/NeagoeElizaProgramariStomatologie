﻿namespace NeagoeElizaProgramariStomatologie.Models
{
    public class Specializare
    {
        public int ID { get; set; }
        public string NumeSpecializare { get; set; }
        public ICollection<Medic>? Medici { get; set; }
    }
}
