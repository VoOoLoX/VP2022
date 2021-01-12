using System;
using System.Linq;
using System.Collections.Generic;
using DataLayer;
using Shared;

namespace BusinessLayer {
	public static class SoldVehicleBusiness {
		public static List<SoldVehicle> GetAll() => Repositories.Instance.SoldVehicleRepository.GetAll();

		public static SoldVehicle Get(int id) => GetAll().FirstOrDefault(sold_vehicle => sold_vehicle.ID == id);

		public static bool Insert(SoldVehicle sold_vehicle) => Repositories.Instance.SoldVehicleRepository.Insert(sold_vehicle);

		public static decimal GetProfit() => GetAll().Sum(sold_vehicle => VehicleBusiness.Get(sold_vehicle.VehicleID).Price);
	}
}
