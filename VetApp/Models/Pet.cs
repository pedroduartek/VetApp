using System;

namespace VetApp.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
        public Type PetType { get; set; }

        public enum Type
        {
            Dog = 1,
            Cat = 2,
            Bird = 3
        }


    }
}
