using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetApp.Models
{
    public class CreatePetViewModel
    {
        public Pet Pet { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
    }
}
