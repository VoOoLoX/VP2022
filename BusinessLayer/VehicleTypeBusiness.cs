using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared;

namespace BusinessLayer {
	public static class VehicleTypeBusiness {
		public static List<VehicleType> GetAll() => Repositories.Instance.VehicleTypeRepository.GetAll();

		public static VehicleType Get(int id) => GetAll().FirstOrDefault(vehicle_type => vehicle_type.ID == id);

		public static int Insert(VehicleType vehicle_type) => Repositories.Instance.VehicleTypeRepository.InsertGetID(vehicle_type);
	}
}
