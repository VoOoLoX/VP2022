using System;
using System.Linq;
using System.Collections.Generic;
using DataLayer;
using Shared;

namespace BusinessLayer {
	public static class VehicleBusiness {
		public static List<Vehicle> GetAll() => Repositories.VehicleRepository.GetAll();

		public static List<Vehicle> GetMostExpensive(int n) => Repositories.VehicleRepository.GetAll().OrderByDescending(car => car.Price).Take(n).ToList();
		public static bool Insert(Vehicle vehicle) => Repositories.VehicleRepository.Insert(vehicle);

		public static Manufacturer GetManufacturer(Vehicle vehicle) => Repositories.ManufacturerRepository.GetAll().Find(manufacturer => manufacturer.ID == vehicle.ManufacturerID);

		public static VehicleModel GetVehicleModel(Vehicle vehicle) => Repositories.VehicleModelRepository.GetAll().Find(model => model.ID == vehicle.ModelID);

		public static VehicleType GetVehicleType(Vehicle vehicle) => Repositories.VehicleTypeRepository.GetAll().Find(type => type.ID == vehicle.TypeID);

		public static Feature GetFeature(Vehicle vehicle) => Repositories.FeatureRepository.GetAll().Find(feature => feature.ID == vehicle.FeaturesID);

		public static Security GetSecurity(Vehicle vehicle) => Repositories.SecurityRepository.GetAll().Find(security => security.ID == vehicle.SecurityID);
	}
}
