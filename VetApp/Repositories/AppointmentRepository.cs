﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VetApp.Interfaces;
using VetApp.Models;

namespace VetApp.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public VetAppDbContext VetAppDbContext => Context as VetAppDbContext;
        public AppointmentRepository(VetAppDbContext context) 
            : base(context)
        {
        }

        

        public IEnumerable<Appointment> GetAppointmentsWithPetsAndOwnersOrderedByDate()
        {
            return VetAppDbContext.Appointments
                .Include(a => a.Pet)
                .ThenInclude(p => p.Owner)
                .OrderBy(a => a.Date).ToList();
        }

        public Appointment GetAppointmentWithDoctorAndPetWithOwner(int id)
        {
            return VetAppDbContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Pet)
                .ThenInclude(p => p.Owner)
                .ToList().Find(a => a.Id == id);
        }
    }
}