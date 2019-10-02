using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.Interfaces
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        IEnumerable<Owner> GetOwnersOrderedByName();
        Owner GetOwnerWithPetsWithAppointments(int id);
    }
}
