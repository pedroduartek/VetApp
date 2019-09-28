using System;
using System.Collections.Generic;
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
            var appointments = _context.Appointments
                .Include(a => a.Pet)
                .ThenInclude(p => p.Owner)
                .OrderBy(a => a.Date).ToList();

            return View(appointments);
        }

        public IActionResult AppointmentDetails(int? id)
        {
            var appointment = _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Pet)
                .ThenInclude(p => p.Owner).ToList().Find(a => a.Id == id);

            return View(appointment);
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


    }
}