using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly VetAppDbContext _context;

        public HomeController()
        {
            _context = new VetAppDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pets()
        {
            var pets = _context.Pets.Include(p => p.Owner).OrderBy(p => p.Id).ToList();

            return View(pets);
        }

        public IActionResult PetDetails(int id)
        {
            var pet = _context.Pets.Find(id);

            return View(pet);
        }


        public IActionResult Owners()
        {
            var owners = _context.Owners.OrderBy(o => o.Id).ToList();

            return View(owners);
        }

        public IActionResult OwnerDetails(int id)
        {
            var owner = _context.Owners.Find(id);

            return View(owner);
        }


        public IActionResult Appointments()
        {
            var appointments = _context.Appointments.Include(a => a.Pet).ThenInclude(p => p.Owner).OrderBy(a => a.Date).ToList();

            return View(appointments);
        }

        public IActionResult AppointmentDetails(int id)
        {
            var appointment = _context.Appointments.Find(id);

            return View(appointment);
        }


        public IActionResult Doctors()
        {
            var doctors = _context.Doctors.OrderBy(a => a.Name).ToList();

            return View(doctors);
        }

        public IActionResult DoctorDetails(int id)
        {
            var doctor = _context.Doctors.Find(id);

            return View(doctor);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
