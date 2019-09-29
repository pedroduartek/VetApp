using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly VetAppDbContext _context;

        public DoctorController()
        {
            _context = new VetAppDbContext();
        }

        public IActionResult Index()
        {
            var doctors = _context.Doctors.OrderBy(a => a.Name).ToList();

            return View(doctors);
        }

        public IActionResult Details(int? id)
        {
            var doctor = _context.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Pet)
                .ToList()
                .Find(d => d.LicenseNumber == id);

            return View(doctor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor newDoctor)
        {
            if (!ModelState.IsValid) return View();

            _context.Doctors.Add(newDoctor);
            _context.SaveChanges();

            return View("Created", newDoctor);
        }

        public IActionResult Created()
        {
            return View();
        }


        public IActionResult Delete(int? id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var doctor = _context.Doctors.Find(id);

            return View(doctor);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            try
            {
                var doctor = _context.Doctors.Find(id);
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return View("Deleted");
        }

        public IActionResult Deleted()
        {
            return View();
        }


    }
}