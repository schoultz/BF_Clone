using Microsoft.AspNetCore.Mvc;
using BostadStockholm.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;

namespace BostadStockholm.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ApartmentsController : ControllerBase
	{
		private readonly IApartmentService _apartmentService;

		public ApartmentsController(IApartmentService apartmentService)
		{
			_apartmentService = apartmentService;
		}

		[HttpGet("available")]
		public IActionResult GetAvailableApartments()
		{
			var apartments = _apartmentService.GetAllAvailableApartments();
			return Ok(apartments);
		}

		[HttpGet("{id}")]
		public IActionResult GetApartmentById(Guid id)
		{
			var apartment = _apartmentService.GetApartmentById(id);
			if (apartment == null)
				return NotFound();
			return Ok(apartment);
		}

		[Authorize]
		[HttpPost("{id}/apply")]
		public IActionResult Apply(Guid id, [FromQuery] Guid userId)
		{
			_apartmentService.ApplyForApartment(id, userId);
			return Ok(new { Message = "Application submitted." });
		}
	}
}