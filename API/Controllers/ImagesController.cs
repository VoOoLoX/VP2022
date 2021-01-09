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
		public class ImgurImage {
			public string link { get; set; }
		}
		public class ImgurResponse {
			public List<ImgurImage> data { get; set; }
		}

		[AllowAnonymous]
		[HttpGet("{vehicle_id:int}")]
		public IActionResult Images(int vehicle_id) {
			return GetImages(vehicle_id);
		}

		public static ImgurResponse GetImgurImages(Vehicle vehicle) {
			var images = VehicleBusiness.GetImage(vehicle) ?? new Image();

			using var client = new HttpClient();

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", Constants.ImgurClientID);

			var response = client.GetAsync(new Uri(Constants.ImgurAPIAlbumImages(images.Link))).Result;

			if (response.StatusCode != HttpStatusCode.OK)
				return new ImgurResponse { data = new List<ImgurImage> { new ImgurImage { link = "https://automobiles.honda.com/-/media/Honda-Automobiles/Vehicles/2021/Civic-Type-R/Feature-Blades/Exterior-Interior/Overview/MY21CivicTypeRExtInt00Overview14002x.jpg" } } };

			var result_string = response.Content.ReadAsStringAsync().Result;

			var result = JsonSerializer.Deserialize<ImgurResponse>(result_string);

			return result;
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

			var result = JsonSerializer.Deserialize<ImgurResponse>(result_string);

			return Ok(new { images = result.data });
		}
	}
}
