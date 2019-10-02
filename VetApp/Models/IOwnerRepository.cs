using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetApp.Models
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        IEnumerable<Owner> GetOwnersOrderedByName();
        Owner GetOwnerWithPetsWithAppointments(int id);
    }
}
