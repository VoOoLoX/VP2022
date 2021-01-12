using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class BrowseController : ControllerBase {
		public struct BrowseInfo {
			public string Manufacturer { get; set; }
			public string Model { get; set; }
			public int YearStart { get; set; }
			public int YearEnd { get; set; }
			public decimal PriceStart { get; set; }
			public decimal PriceEnd { get; set; }
			public string Sort { get; set; }
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult Browse([FromBody] BrowseInfo browse_info) {
			return FilterBrowse(browse_info);
		}

		private IActionResult FilterBrowse(BrowseInfo browse_info) {
			var vehicles = VehicleBusiness.GetAllAvailable();

			if (!string.IsNullOrEmpty(browse_info.Manufacturer))
				vehicles = vehicles.Where(v => VehicleBusiness.GetManufacturer(v).Name.ToLower().Contains(browse_info.Manufacturer.ToLower())).ToList();
			if (!string.IsNullOrEmpty(browse_info.Model))
				vehicles = vehicles.Where(v => VehicleBusiness.GetVehicleModel(v).Name.ToLower().Contains(browse_info.Model.ToLower())).ToList();
			if (browse_info.YearStart != 0)
				vehicles = vehicles.Where(v => v.Year >= browse_info.YearStart).ToList();
			if (browse_info.YearEnd != 0)
				vehicles = vehicles.Where(v => v.Year <= browse_info.YearEnd).ToList();
			if (browse_info.PriceStart > decimal.Zero)
				vehicles = vehicles.Where(v => v.Price >= browse_info.PriceStart).ToList();
			if (browse_info.PriceEnd > decimal.Zero)
				vehicles = vehicles.Where(v => v.Price <= browse_info.PriceEnd).ToList();

			
			var results = vehicles.Select(v => new {
				ID = v.ID,
				Price = v.Price,
				Manufacturer = VehicleBusiness.GetManufacturer(v).Name,
				Model = VehicleBusiness.GetVehicleModel(v).Name,
				Year = v.Year,
				Milage = v.Mileage,
				CubicCapacity = v.CubicCapacity,
				VehicleType = VehicleBusiness.GetVehicleType(v).Name,
				Fuel = v.Fuel,
				Image = ImagesController.GetImgurImages(v).data.FirstOrDefault().link
			}).ToList();

			switch (browse_info.Sort.ToLower()) {
				case "price_desc":
					results = results.OrderByDescending(v => v.Price).ToList();
					break;
				case "price_asc":
					results = results.OrderBy(v => v.Price).ToList();
					break;
				case "year_desc":
					results = results.OrderByDescending(v => v.Year).ToList();
					break;
				case "year_asc":
					results = results.OrderBy(v => v.Year).ToList();
					break;
				default:
					break;
			}

			return Ok(new { results = results.Count, vehicles = results });
		}
	}
}
