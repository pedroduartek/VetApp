using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Pet Pet { get; set; }
        public int PetId { get; set; }
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

        public Appointment()
        {
            var context = new VetAppDbContext();

            var petType = Pet.PetType.ToString();

            var doctor = context.Doctors.Where(d => d.Specialty.ToString() == petType).ToList();

            var rnd = new Random();

            DoctorId = doctor[rnd.Next(0,doctor.Count)].LicenseNumber;
        }
    }
}
