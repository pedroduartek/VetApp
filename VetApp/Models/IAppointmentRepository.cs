using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetApp.Models
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetAppointmentsWithPetsAndOwnersOrderedByDate();
        Appointment GetAppointmentWithDoctorAndPetWithOwner(int id);
    }
}
