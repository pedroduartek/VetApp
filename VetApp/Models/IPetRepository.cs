using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetApp.Models
{
    public interface IPetRepository : IRepository<Pet>
    {
        IEnumerable<Pet> GetPetsWithOwnersOrderedByName();
        IEnumerable<Pet> GetPetsWithOwnersOrderedById();
        Pet GetPetWithOwnerAndAppointmentsWithDoctor(int id);
    }
}
