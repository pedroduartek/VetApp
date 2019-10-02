using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.Models
{
    public class CreateAppointmentViewModel
    {
        public IEnumerable<Doctor> Doctors { get; set; }
        public Appointment Appointment { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}