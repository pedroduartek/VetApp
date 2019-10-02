using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetAppointmentsWithPetsAndOwnersOrderedByDate();
        Appointment GetAppointmentWithDoctorAndPetWithOwner(int id);
    }
}
