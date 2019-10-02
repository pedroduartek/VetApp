using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.ViewModels
{
    public class AppointmentsViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
