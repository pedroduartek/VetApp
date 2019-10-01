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
    public class AppointmentController : Controller
    {
        private readonly VetAppDbContext _context;

        public AppointmentController()
        {
            _context = new VetAppDbContext();
        }
        public IActionResult Index()
        {
            var viewModel = new AppointmentsViewModel();
            viewModel.Appointments = _context.Appointments
                .Include(a => a.Pet)
                .ThenInclude(p => p.Owner)
                .OrderBy(a => a.Date).ToList();
            viewModel.Doctors = _context.Doctors.ToList();

            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            var appointment = _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Pet)
                .ThenInclude(p => p.Owner)
                .ToList().Find(a => a.Id == id);

            return View(appointment);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAppointmentViewModel
            {
                Doctors = _context.Doctors.ToList(),
                Pets = _context.Pets.ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateAppointmentViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();

            _context.Appointments.Add(viewModel.Appointment);
            _context.SaveChanges();
            return View("Created", viewModel.Appointment);

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
            var appointment = _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Pet)
                .ThenInclude(p => p.Owner)
                .ToList().Find(a => a.Id == id);

            return View(appointment);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            try
            {
                var appointment = _context.Appointments.Find(id);
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return View("Deleted");
        }
        
    }
}