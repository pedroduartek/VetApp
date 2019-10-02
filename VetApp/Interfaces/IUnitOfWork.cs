using System;

namespace VetApp.Interfaces
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
