using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetApp.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IDoctorRepository Doctors { get; }
        IPetRepository Pets { get; }
        IOwnerRepository Owners { get; }
        int Complete();
    }
}
