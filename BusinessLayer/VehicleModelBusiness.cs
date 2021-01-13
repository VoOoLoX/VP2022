using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared;

namespace BusinessLayer {
	public static class VehicleModelBusiness {
		public static List<VehicleModel> GetAll() => Repositories.Instance.VehicleModelRepository.GetAll();

		public static VehicleModel Get(int id) => GetAll().FirstOrDefault(vehicle_model => vehicle_model.ID == id);

		public static int Insert(VehicleModel vehicle_model) => Repositories.Instance.VehicleModelRepository.InsertGetID(vehicle_model);
	}
}
