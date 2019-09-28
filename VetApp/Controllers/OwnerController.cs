using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class OwnerController : Controller
    {
        private readonly VetAppDbContext _context;

        public OwnerController()
        {
            _context = new VetAppDbContext();
        }

        public IActionResult Index()
        {
            var owners = _context.Owners.OrderBy(o => o.Id).ToList();

            return View(owners);
        }
        public IActionResult Details(int? id)
        {
            var owner = _context.Owners
                .Include(o => o.Pets)
                .ThenInclude(p => p.Appointments)
                .ToList().Find(o => o.Id == id);


            return View(owner);
        }

        public IActionResult Create()
        {
            var newOwner = new Owner();

            return View(newOwner);
        }

        [HttpPost]
        public IActionResult Create(Owner newOwner)
        {
            if (!ModelState.IsValid) return View();

            _context.Owners.Add(newOwner);
            _context.SaveChanges();
            return RedirectToAction("Create", "Pet");

        }
    }
}