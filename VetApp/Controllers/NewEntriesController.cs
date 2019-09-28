using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class NewEntriesController : Controller
    {
        private readonly VetAppDbContext _context;

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
                return View("PetAdded", newPet);
            }
            else
            {
                return View();
            }
        }

        public IActionResult AddOwner()
        {
            var newOwner = new Owner();

            return View(newOwner);
        }

        [HttpPost]
        public IActionResult AddOwner(Owner newOwner)
        {
            if (!ModelState.IsValid) return View();

            _context.Owners.Add(newOwner);
            _context.SaveChanges();
            return View("AddPet");

        }


        public IActionResult AddAppointment()
        {
            var viewModel = new AddAppointmentViewModel
            {
                Doctors = _context.Doctors.ToList(), 
                Pets = _context.Pets.ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddAppointment(AddAppointmentViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();

            _context.Appointments.Add(viewModel.Appointment);
            _context.SaveChanges();
            return View("AppointmentAdded", viewModel.Appointment);

        }


        public IActionResult AddDoctor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor newDoctor)
        {
            if (!ModelState.IsValid) return View();

            _context.Doctors.Add(newDoctor);
            _context.SaveChanges();

            return View("DoctorAdded", newDoctor);

        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        
    }
}