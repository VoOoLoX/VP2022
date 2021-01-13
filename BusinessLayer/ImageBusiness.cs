using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared;

namespace BusinessLayer {
	public static class ImageBusiness {
		public static List<Image> GetAll() => Repositories.Instance.ImageRepository.GetAll();

		public static Image Get(int id) => GetAll().FirstOrDefault(image => image.ID == id);

		public static int Insert(Image image) => Repositories.Instance.ImageRepository.InsertGetID(image);
	}
}
