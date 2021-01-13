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
	public class OrderController : ControllerBase {
		public struct OrderInfo {
			public int VehicleID { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Country { get; set; }
			public string City { get; set; }
			public string Street { get; set; }
			public string Zip { get; set; }

		}

		[AllowAnonymous]
		[HttpGet("{vehicle_id:int}")]
		public IActionResult Order(int vehicle_id) {
			return GetVehicle(vehicle_id);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Order(OrderInfo order_info) {
			return PostVehicle(order_info);
		}

		private IActionResult GetVehicle(int vehicle_id) {
			var vehicle = VehicleBusiness.Get(vehicle_id);

			if (vehicle == null)
				return NotFound();

			var result = new {
				ID = vehicle.ID,
				Price = vehicle.Price,
				Manufacturer = VehicleBusiness.GetManufacturer(vehicle).Name,
				Model = VehicleBusiness.GetVehicleModel(vehicle).Name,
				Year = vehicle.Year,
				Milage = vehicle.Mileage,
				CubicCapacity = vehicle.CubicCapacity,
				VehicleType = VehicleBusiness.GetVehicleType(vehicle).Name,
				Fuel = vehicle.Fuel,
				Image = ImageUtils.GetImgurImages(VehicleBusiness.GetImage(vehicle).Link).Data.FirstOrDefault().Link
			};

			return Ok(new { vehicle = result });
		}

		private IActionResult PostVehicle(OrderInfo order_info) {
			var vehicle = VehicleBusiness.Get(order_info.VehicleID);

			if (vehicle == null)
				return NotFound(new { message = "Vozilo nije pronađeno." });

			var order = new Order() {
				FirstName = order_info.FirstName,
				LastName = order_info.LastName,
				Country = order_info.Country,
				City = order_info.City,
				Street = order_info.Street,
				PostalCode = int.Parse(order_info.Zip)
			};
			//FIX Postal code should be string

			var order_id = OrderBusiness.Insert(order);

			var sold_vehicle = new SoldVehicle() {
				Date = DateTime.Now,
				VehicleID = order_info.VehicleID,
				OrderID = order_id
			};

			var result = SoldVehicleBusiness.Insert(sold_vehicle);

			if (result)
				return Ok(new { message = "Porudžbina uspešna." });
			else
				return BadRequest(new { message = "Došlo je do grešeke pri porudžbini." });
		}
	}
}
