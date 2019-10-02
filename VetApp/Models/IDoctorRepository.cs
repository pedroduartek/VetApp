using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetApp.Models;

namespace VetApp.Models
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Doctor GetDoctorWithAppointmentsWithPet(int id);
        IEnumerable<Doctor> GetDoctorsOrderedByName();
    }
}
