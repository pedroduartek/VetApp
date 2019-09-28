using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
