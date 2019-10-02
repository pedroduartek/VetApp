using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetApp.Interfaces;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var doctors = _unitOfWork.Doctors.GetDoctorsOrderedByName();
            
            return View(doctors);
        }

        public IActionResult Details(int id)
        {
            var doctor = _unitOfWork.Doctors.GetDoctorWithAppointmentsWithPet(id);

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

            _unitOfWork.Doctors.Add(newDoctor);
            _unitOfWork.Complete();

            return View("Created", newDoctor);
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

            var doctor = _unitOfWork.Doctors.GetDoctorWithAppointmentsWithPet(id);

            

            return View(doctor);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var doctor = _unitOfWork.Doctors.Get(id);
                _unitOfWork.Doctors.Remove(doctor);
                _unitOfWork.Complete();
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