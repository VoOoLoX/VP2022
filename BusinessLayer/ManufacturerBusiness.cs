using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared;

namespace BusinessLayer {
	public static class ManufacturerBusiness {
		public static List<Manufacturer> GetAll() => Repositories.Instance.ManufacturerRepository.GetAll();

		public static Manufacturer Get(int id) => GetAll().FirstOrDefault(manufacturer => manufacturer.ID == id);

		public static int Insert(Manufacturer manufacturer) => Repositories.Instance.ManufacturerRepository.InsertGetID(manufacturer);
	}
}
