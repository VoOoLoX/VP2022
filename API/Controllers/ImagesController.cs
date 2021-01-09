using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase {
		[AllowAnonymous]
		[HttpGet("{vehicle_id:int}")]
		public IActionResult Images(int vehicle_id) {
			return GetImages(vehicle_id);
		}

		private IActionResult GetImages(int vehicle_id) {
			var vehicle = VehicleBusiness.Get(vehicle_id);

			if (vehicle == null)
				return NotFound();

			var images = VehicleBusiness.GetImage(vehicle) ?? new Image();

			using var client = new HttpClient();

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", Constants.ImgurClientID);

			var response = client.GetAsync(new Uri(Constants.ImgurAPIAlbumImages(images.Link))).Result;
			
			if (response.StatusCode != HttpStatusCode.OK)
				return NotFound();

			var result_string = response.Content.ReadAsStringAsync().Result;

			return Ok(result_string);
		}
	}
}
