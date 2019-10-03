using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.ViewModel
{
    public class CreateUpdateAppointmentViewModel
    {
        public ICollection<Doctor> Doctors { get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}