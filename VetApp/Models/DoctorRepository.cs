using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetApp.Migrations;

namespace VetApp.Models
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public VetAppDbContext VetAppDbContext => Context;
        public DoctorRepository(VetAppDbContext context)
            : base(context)
        {
        }

        public Doctor GetDoctorWithAppointmentsWithPet(int id)
        {
            return VetAppDbContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Pet)
                .ToList()
                .Find(d => d.LicenseNumber == id);
        }

        public IEnumerable<Doctor> GetDoctorsOrderedByName()
        {
            return VetAppDbContext.Doctors
                .OrderBy(a => a.Name).ToList();
        }
    }
}
