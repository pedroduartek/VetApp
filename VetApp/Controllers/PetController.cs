﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class PetController : Controller
    {
        private readonly VetAppDbContext _context;

        public PetController()
        {
            _context = new VetAppDbContext();
        }

        public IActionResult OwnerRegistered()
        {
            return View();
        }
        public IActionResult Index()
        {
            var pets = _context.Pets
                .Include(p => p.Owner)
                .OrderBy(p => p.Id).ToList();

            return View(pets);
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePetViewModel() {Owners = _context.Owners.ToList()};

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreatePetViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();
            _context.Pets.Add(viewModel.Pet);
            _context.SaveChanges();

            return View("Created", viewModel.Pet);
        }

        public IActionResult Created()
        {
            return View();
        }



        public IActionResult Details(int id)
        {
            var pet = _context.Pets
                .Include(p => p.Owner)
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToList().Find(p => p.Id == id);

            return View(pet);
        }

        public IActionResult Delete(int? id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            var pet = _context.Pets
                .Include(p => p.Owner)
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToList().Find(p => p.Id == id);


            return View(pet);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            try
            {
                var pet = _context.Pets.Find(id);

                _context.Pets.Remove(pet);
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