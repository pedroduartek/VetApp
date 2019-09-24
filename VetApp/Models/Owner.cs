using System;
using System.Collections.Generic;

namespace VetApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Contact { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public int AnimalId { get; set; }
    }
}