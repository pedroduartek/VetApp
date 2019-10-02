using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Doctor GetDoctorWithAppointmentsWithPet(int id);
        IEnumerable<Doctor> GetDoctorsOrderedByName();
    }
}
