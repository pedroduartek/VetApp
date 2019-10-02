using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VetApp.Interfaces;
using VetApp.Models;

namespace VetApp.Repositories
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public VetAppDbContext VetAppDbContext => Context;
        public OwnerRepository(VetAppDbContext context) 
            : base(context)
        {
        }

        public IEnumerable<Owner> GetOwnersOrderedByName()
        {
            return VetAppDbContext.Owners
                .OrderBy(o => o.Name)
                .ToList();
        }

        public Owner GetOwnerWithPetsWithAppointments(int id)
        {
            return VetAppDbContext.Owners
                .Include(o => o.Pets)
                .ThenInclude(p => p.Appointments)
                .ToList().Find(o => o.Id == id);
        }
    }
}