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
    public class PetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OwnerRegistered()
        {
            var owners = _unitOfWork.Owners.GetAll();
            return View(owners);
        }
        public IActionResult Index()
        {
            var pets = _unitOfWork.Pets.GetPetsWithOwnersOrderedByName();

            return View(pets);
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePetViewModel() {Owners = _unitOfWork.Owners.GetAll()};

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreatePetViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();
            _unitOfWork.Pets.Add(viewModel.Pet);
            _unitOfWork.Complete();

            return View("Created", viewModel.Pet);
        }

        public IActionResult Created()
        {
            return View();
        }



        public IActionResult Details(int id)
        {
            var pet = _unitOfWork.Pets.GetPetWithOwnerAndAppointmentsWithDoctor(id);

            

            return View(pet);
        }

        public IActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            var pet = _unitOfWork.Pets.GetPetWithOwnerAndAppointmentsWithDoctor(id);


            return View(pet);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var pet = _unitOfWork.Pets.Get(id);

                _unitOfWork.Pets.Remove(pet);
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