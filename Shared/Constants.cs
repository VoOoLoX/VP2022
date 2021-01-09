using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared {
	public static class Constants {
		public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SI2020Project;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		public static string ImgurClientID = @"b22f9c8a537a28b";
		public static string ImgurClientSecret = @"9ad66f1743715fc4ec2322a622edeb5a9fb24e3f";
		public static string ImgurAPIAlbumImages(string id) => $"https://api.imgur.com/3/album/{id}/images";
	}
}
