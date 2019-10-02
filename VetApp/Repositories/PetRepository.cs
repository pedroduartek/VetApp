using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VetApp.Interfaces;
using VetApp.Models;

namespace VetApp.Repositories
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
