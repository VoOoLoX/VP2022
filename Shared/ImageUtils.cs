using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared {
	public static class ImageUtils {
		public static ImgurResponse GetImgurImages(string album_id) {
			using var client = new HttpClient();

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", Constants.ImgurClientID);

			var response = client.GetAsync(new Uri(Constants.ImgurAPIAlbumImages(album_id))).Result;

			if (response.StatusCode != HttpStatusCode.OK)
				return new ImgurResponse { Data = new List<ImgurImage> { new ImgurImage { Link = "https://automobiles.honda.com/-/media/Honda-Automobiles/Vehicles/2021/Civic-Type-R/Feature-Blades/Exterior-Interior/Overview/MY21CivicTypeRExtInt00Overview14002x.jpg" } } };

			var result_string = response.Content.ReadAsStringAsync().Result;

			var result = JsonSerializer.Deserialize<ImgurResponse>(result_string);

			return result;
		}
	}
}
