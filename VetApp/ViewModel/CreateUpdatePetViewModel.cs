using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.ViewModel
{
    public class CreateUpdatePetViewModel
    {
        public Pet Pet { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
