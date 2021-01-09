using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class TopVehiclesController : ControllerBase {
		public struct TopVehiclesInfo {
			public int Count { get; set; }
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult TopVehicles([FromBody] TopVehiclesInfo top_vehicles_info) {
			return GetTopVehicles(top_vehicles_info);
		}

		private IActionResult GetTopVehicles(TopVehiclesInfo top_vehicles_info) {
			var vehicles = VehicleBusiness.GetMostExpensive(top_vehicles_info.Count);

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
				Image = ImagesController.GetImgurImages(v)?.data.FirstOrDefault().link ?? ""
			}).ToList();

			return Ok(new { results = results.Count, vehicles = results });
		}
	}
}
