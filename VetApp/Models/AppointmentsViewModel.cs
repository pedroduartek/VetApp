using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetApp.Models
{
    public class AppointmentsViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
