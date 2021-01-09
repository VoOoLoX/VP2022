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
	public class VehicleController : ControllerBase {
		public struct VehiclesInfo {
			public int Id { get; set; }
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult Vehicle(VehiclesInfo vehicles_info) {
			return GetVehicle(vehicles_info);
		}

		private IActionResult GetVehicle(VehiclesInfo vehicles_info) {
			var vehicle = VehicleBusiness.Get(vehicles_info.Id);

			if (vehicle == null)
				return NotFound();

			var feature = VehicleBusiness.GetFeature(vehicle) ?? new Feature();
			var security = VehicleBusiness.GetSecurity(vehicle) ?? new Security();

			var result = new {
				ID = vehicle.ID,
				Price = vehicle.Price,
				Manufacturer = VehicleBusiness.GetManufacturer(vehicle).Name,
				Model = VehicleBusiness.GetVehicleModel(vehicle).Name,
				Year = vehicle.Year,
				Milage = vehicle.Mileage,
				CubicCapacity = vehicle.CubicCapacity,
				HorsePower = vehicle.HorsePower,
				VehicleType = VehicleBusiness.GetVehicleType(vehicle).Name,
				Fuel = vehicle.Fuel,
				Description = vehicle.Description,
				Features = new {
					CruiseControl = feature.CruiseControl,
					ParkingSensors = feature.ParkingSensors,
					ElectricWindows = feature.ElectricWindows,
					Sunroof = feature.Sunroof,
					XenonHeadlights = feature.XenonHeadlights,
					Multimedia = feature.Multimedia,
					Navigation = feature.Navigation,
					AirConditioning = feature.AirConditioning
				},
				Security = new {
					Airbag = security.Airbag,
					ESP = security.ESP,
					ASR = security.ASR,
					ABS = security.ABS,
					ChildLock = security.ChildLock,
					Immobiliser = security.Immobiliser,
					CentralLocking = security.CentralLocking
				} 
			};

			return Ok(new { vehicle = result });
		}
	}
}
