using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VetApp.Models
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {

        public VetAppDbContext VetAppDbContext => Context as VetAppDbContext;

        public PetRepository(VetAppDbContext context) 
            : base(context)
        {
        }

        public IEnumerable<Pet> GetPetsWithOwnersOrderedByName()
        {
            return VetAppDbContext.Pets
                .Include(p => p.Owner)
                .OrderBy(p => p.Name).ToList();
        }

        public IEnumerable<Pet> GetPetsWithOwnersOrderedById()
        {
            return VetAppDbContext.Pets
                .Include(p => p.Owner)
                .OrderBy(p => p.Id).ToList();
        }

        public Pet GetPetWithOwnerAndAppointmentsWithDoctor(int id)
        {
            return VetAppDbContext.Pets
                .Include(p => p.Owner)
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToList().Find(p => p.Id == id);
        }


    }
}
