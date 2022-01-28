using System;
using System.Linq;
using System.Collections.Generic;
using DataLayer;
using Shared;

namespace BusinessLayer {
	public static class VehicleBusiness {
		public static List<Vehicle> GetAll() => Repositories.Instance.VehicleRepository.GetAll();

		public static List<Vehicle> GetAllAvailable() => GetAll().Where(vehicle => SoldVehicleBusiness.GetAll().All(sold_vehicle => vehicle.ID != sold_vehicle.VehicleID)).ToList();

		public static List<Vehicle> GetMostExpensive(int n) => GetAllAvailable().OrderByDescending(car => car.Price).Take(n).ToList();

		public static Vehicle Get(int id) => GetAll().FirstOrDefault(vehicle => vehicle.ID == id);

		public static bool Insert(Vehicle vehicle) => Repositories.Instance.VehicleRepository.Insert(vehicle);

		public static bool Delete(Vehicle vehicle) => Repositories.Instance.VehicleRepository.Delete(vehicle);

		public static Manufacturer GetManufacturer(Vehicle vehicle) => Repositories.Instance.ManufacturerRepository.GetAll().Find(manufacturer => manufacturer.ID == vehicle.ManufacturerID);

		public static VehicleModel GetVehicleModel(Vehicle vehicle) => Repositories.Instance.VehicleModelRepository.GetAll().Find(model => model.ID == vehicle.ModelID);

		public static VehicleType GetVehicleType(Vehicle vehicle) => Repositories.Instance.VehicleTypeRepository.GetAll().Find(type => type.ID == vehicle.TypeID);

		public static Feature GetFeature(Vehicle vehicle) => Repositories.Instance.FeatureRepository.GetAll().Find(feature => feature.ID == vehicle.FeaturesID);

		public static Security GetSecurity(Vehicle vehicle) => Repositories.Instance.SecurityRepository.GetAll().Find(security => security.ID == vehicle.SecurityID);

		public static Image GetImage(Vehicle vehicle) => Repositories.Instance.ImageRepository.GetAll().Find(image => image.ID == vehicle.ImagesID);
	}
}
