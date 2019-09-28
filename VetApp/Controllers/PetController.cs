using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class PetController : Controller
    {
        private readonly VetAppDbContext _context;

        public PetController()
        {
            _context = new VetAppDbContext();
        }

        public IActionResult OwnerRegistered()
        {
            return View();
        }
        public IActionResult Index()
        {
            var pets = _context.Pets
                .Include(p => p.Owner)
                .OrderBy(p => p.Id).ToList();

            return View(pets);
        }

        public IActionResult Create()
        {
            var newPet = new Pet();

            return View(newPet);
        }

        [HttpPost]
        public IActionResult Create(Pet newPet)
        {
            if (!ModelState.IsValid) return View();
            _context.Pets.Add(newPet);
            _context.SaveChanges();
            return View("PetAdded", newPet);

        }

        

        public IActionResult Details(int id)
        {
            var pet = _context.Pets
                .Include(p => p.Owner)
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToList().Find(p => p.Id == id);

            return View(pet);
        }


    }
}