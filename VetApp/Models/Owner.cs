using System;
using System.Collections.Generic;

namespace VetApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Contact { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }

}