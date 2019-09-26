using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class NewEntriesController : Controller
    {
        private VetAppDbContext _context { get; set; }

        public NewEntriesController()
        {
            _context = new VetAppDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPet()
        {
            var newPet = new Pet();
            return View(newPet);
        }

        [HttpPost]
        public IActionResult AddPet(Pet newPet)
        {
            if (ModelState.IsValid)
            {
                _context.Pets.Add(newPet);
                _context.SaveChanges();
            }
            return View("PetAdded");
        }

        public IActionResult AddOwner()
        {
            var newOwner = new Owner();

            return View(newOwner);
        }
        
        [HttpPost]
        public IActionResult AddOwner(Owner newOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Owners.Add(newOwner);
                _context.SaveChanges();
            }
            
            return View("AddPet");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        


    }
}
