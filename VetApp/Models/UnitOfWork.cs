using System;
using VetApp.Interfaces;
using VetApp.Repositories;

namespace VetApp.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VetAppDbContext _context;

        public UnitOfWork(VetAppDbContext context)
        {
            _context = context;
            Owners = new OwnerRepository(context);
            Pets = new PetRepository(context);
            Doctors = new DoctorRepository(context);
            Appointments = new AppointmentRepository(context);
        }

        public IAppointmentRepository Appointments { get; private set; }
        public IDoctorRepository Doctors { get; private set; }
        public IPetRepository Pets { get; private set; }
        public IOwnerRepository Owners { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}