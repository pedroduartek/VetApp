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
    public class OwnerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var owners = _unitOfWork.Owners.GetOwnersOrderedByName();

            return View(owners);
        }
        public IActionResult Details(int id)
        {
            var owner = _unitOfWork.Owners.GetOwnerWithPetsWithAppointments(id);


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

            _unitOfWork.Owners.Add(newOwner);
            _unitOfWork.Complete();

            return RedirectToAction("Create", "Pet");
        }

        public IActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            var owner = _unitOfWork.Owners.GetOwnerWithPetsWithAppointments(id);


            return View(owner);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var owner = _unitOfWork.Owners.Get(id);
                _unitOfWork.Owners.Remove(owner);
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