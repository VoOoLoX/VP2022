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
		[HttpGet]
		[Authorize]
		[HttpGet("{id}", Name = "GetVehicle")]
		public ActionResult<Vehicle> Get(int id) {
			return VehicleBusiness.Get(id);
		}
	}
}
