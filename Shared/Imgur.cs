using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared {
	public class ImgurImage {
		[JsonPropertyName("link")]
		public string Link { get; set; }
	}

	public class ImgurResponse {
		[JsonPropertyName("data")]
		public List<ImgurImage> Data { get; set; }
	}
}
