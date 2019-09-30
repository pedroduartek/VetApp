using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.Models
{
    public class CreateAppointmentViewModel
    {
        public ICollection<Doctor> Doctors { get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}