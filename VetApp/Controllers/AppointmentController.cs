using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetApp.Interfaces;
using VetApp.Models;
using VetApp.ViewModels;

namespace VetApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var viewModel = new AppointmentsViewModel
            {
                Appointments = _unitOfWork.Appointments.GetAppointmentsWithPetsAndOwnersOrderedByDate(),
                Doctors = _unitOfWork.Doctors.GetDoctorsOrderedByName()
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var appointment = _unitOfWork.Appointments.GetAppointmentWithDoctorAndPetWithOwner(id);

            return View(appointment);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAppointmentViewModel
            {
                Doctors = _unitOfWork.Doctors.GetDoctorsOrderedByName(),
                Pets = _unitOfWork.Pets.GetPetsWithOwnersOrderedByName()
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateAppointmentViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();

            _unitOfWork.Appointments.Add(viewModel.Appointment);
            _unitOfWork.Complete();
            return View("Created", viewModel.Appointment);

        }

        public IActionResult Created()
        {
            return View();
        }

        public IActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            var appointment = _unitOfWork.Appointments.GetAppointmentWithDoctorAndPetWithOwner(id);

            return View(appointment);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var appointment = _unitOfWork.Appointments.Get(id);
                _unitOfWork.Appointments.Remove(appointment);
                _unitOfWork.Complete();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return View("Deleted");
        }
        
    }
}