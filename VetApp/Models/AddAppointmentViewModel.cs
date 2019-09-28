using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class AddAppointmentViewModel
    {
        public ICollection<Doctor> Doctors { get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}