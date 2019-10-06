using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetApp.Models;
using VetApp.ViewModel;

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
            var viewModel = new CreateUpdateAppointmentViewModel
            {
                Doctors = _context.Doctors.ToList(),
                Pets = _context.Pets.Include(p => p.Owner).ToList(),
                Appointment = new Appointment()

            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateAppointmentViewModel viewModel, bool sendEmail)
        {
            if (!ModelState.IsValid) return View();

            _context.Appointments.Add(viewModel.Appointment);
            _context.SaveChanges();

            if (!sendEmail) return View("Created", viewModel.Appointment);

            var appointment = _context.Appointments
                .Include(a => a.Pet)
                .ThenInclude(p => p.Owner)
                .Include(a => a.Doctor).ToList()
                .Find(a => a.Id == viewModel.Appointment.Id);

            var ownerEmail = appointment.Pet.Owner.Email;
            var doctorEmail = appointment.Doctor.Email;


            var message = new MailMessage();

            message.To.Add(new MailAddress(ownerEmail));
            message.From = new MailAddress("vetappemail@gmail.com", "VetApp");
            message.Bcc.Add(new MailAddress(doctorEmail));
            message.Subject = "VeApp - Appointment to " + appointment.Pet.Name;
            message.Body =
                "<p>An appointment was booked to " + appointment.Pet.Name + " to " +
                appointment.Date.Day +"/"+ appointment.Date.Month + "/" + appointment.Date.Year + " " +
                appointment.Date.Hour + ":" + appointment.Date.Minute +
                " with Doctor " + appointment.Doctor.Name + ".</p>" +
                "<p>For more details or to change this appointment, contact us.</p>" +
                "<br/>" +
                "<p>This is an automatic email, please do not reply.</p>";
            message.IsBodyHtml = true;


            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("vetappemail@gmail.com ", "vetapppw"),
                EnableSsl = true
            };

            client.Send(message);

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

        public IActionResult Update(int? id)
        {
            var viewModel = new CreateUpdateAppointmentViewModel()
            {
                Appointment = _context.Appointments.Find(id),
                Doctors = _context.Doctors.ToList(),
                Pets = _context.Pets.ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(int? id, [Bind("Id, PetId, DoctorId, Date")] Appointment appointment)
        {

            if (id != appointment.Id) return NotFound();

            if (!ModelState.IsValid) return View("Update");


            _context.Appointments.Attach(appointment);
            _context.Entry(appointment).State = EntityState.Modified;
            _context.SaveChanges();

            return View("Updated", appointment);

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