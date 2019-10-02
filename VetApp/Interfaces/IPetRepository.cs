using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.Interfaces
{
    public interface IPetRepository : IRepository<Pet>
    {
        IEnumerable<Pet> GetPetsWithOwnersOrderedByName();
        IEnumerable<Pet> GetPetsWithOwnersOrderedById();
        Pet GetPetWithOwnerAndAppointmentsWithDoctor(int id);
    }
}
