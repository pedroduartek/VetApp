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

        public IActionResult Owners()
        {
            var owners = _context.Owners.OrderBy(o => o.Id).ToList();

            return View(owners);
        }


        public IActionResult Appointments()
        {
            var appointments = _context.Appointments.Include(a => a.Pet.Owner).OrderBy(a => a.Date).ToList();

            return View(appointments);
        }


        public IActionResult Doctors()
        {
            var doctors = _context.Doctors.OrderBy(a => a.Name).ToList();

            return View(doctors);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
