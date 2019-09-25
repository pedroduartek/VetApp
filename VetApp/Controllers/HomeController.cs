using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class HomeController : Controller
    {
        private VetAppDbContext _context { get; set; }

        public HomeController()
        {
            _context = new VetAppDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AddPet()
        {
            var pets = _context.Pets;
            return View(pets);
        }

        [HttpPost]
        public IActionResult AddPet(AddPetViewModel viewModel)
        {
            
            return View();
        }

    }
}
