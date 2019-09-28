using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetApp.Models
{
    public class Doctor
    {
        public int LicenseNumber { get; set; }
        public string Name { get; set; }
        public SpecialtyType Specialty { get; set; }
        public DateTime Birthday { get; set; }
        public string Contact { get; set; }
        public ICollection<Appointment> Appointments { get; set; }


        public enum SpecialtyType
        {
            Dogs = 1,
            Cats = 2,
            Birds = 3
        }
    }
}
