using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.ViewModel
{
    public class AppointmentsViewModel
    {
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
