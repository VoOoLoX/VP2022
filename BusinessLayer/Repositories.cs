using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using Shared;

namespace BusinessLayer {
	public static class Repositories {
		public static readonly DatabaseContext DatabaseContext = new SqlDatabaseContext(Constants.ConnectionString);

		public static readonly FeatureRepository FeatureRepository = new FeatureRepository(DatabaseContext, "Features");
		public static readonly ImageRepository ImageRepository = new ImageRepository(DatabaseContext, "Images");
		public static readonly ManufacturerRepository ManufacturerRepository = new ManufacturerRepository(DatabaseContext, "Manufacturers");
		public static readonly OrderRepository OrderRepository = new OrderRepository(DatabaseContext, "Orders");
		public static readonly RoleRepository RoleRepository = new RoleRepository(DatabaseContext, "Roles");
		public static readonly SecurityRepository SecurityRepository = new SecurityRepository(DatabaseContext, "Security");
		public static readonly SoldVehicleRepository SoldVehicleRepository = new SoldVehicleRepository(DatabaseContext, "SoldVehicles");
		public static readonly UserRepository UserRepository = new UserRepository(DatabaseContext, "Users");
		public static readonly VehicleModelRepository VehicleModelRepository = new VehicleModelRepository(DatabaseContext, "VehicleModels");
		public static readonly VehicleRepository VehicleRepository = new VehicleRepository(DatabaseContext, "Vehicles");
		public static readonly VehicleTypeRepository VehicleTypeRepository = new VehicleTypeRepository(DatabaseContext, "VehicleTypes");
	}
}
