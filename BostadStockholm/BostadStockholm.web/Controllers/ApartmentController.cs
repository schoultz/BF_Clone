using Microsoft.AspNetCore.Mvc;
using BostadStockholm.Services.Interfaces;
using System;

namespace BostadStockholm.web.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        public IActionResult Index()
        {
            var apartments = _apartmentService.GetAllAvailableApartments();
            return View(apartments);
        }

        public IActionResult Details(Guid id)
        {
            var apartment = _apartmentService.GetApartmentById(id);
            if (apartment == null)
                return NotFound();
            return View(apartment);
        }
    }
}