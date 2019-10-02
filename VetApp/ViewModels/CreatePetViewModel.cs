using System.Collections.Generic;
using VetApp.Models;

namespace VetApp.ViewModels
{
    public class CreatePetViewModel
    {
        public Pet Pet { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
    }
}
