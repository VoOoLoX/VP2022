using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using Shared;

namespace BusinessLayer {
	public sealed class Repositories {
		static readonly Lazy<Repositories> lazy = new Lazy<Repositories>(() => new Repositories());

		public static Repositories Instance => lazy.Value;

		static string connection_string = Constants.ConnectionString;
		public string ConnectionString { get => connection_string; set => connection_string = value; }

		static DatabaseContext database_context = new SqlDatabaseContext(connection_string);
		public DatabaseContext DatabaseContext { get => database_context; set => database_context = value; }

		private Repositories() {}

		public FeatureRepository FeatureRepository = new FeatureRepository(database_context, "Features");
		public ImageRepository ImageRepository = new ImageRepository(database_context, "Images");
		public ManufacturerRepository ManufacturerRepository = new ManufacturerRepository(database_context, "Manufacturers");
		public OrderRepository OrderRepository = new OrderRepository(database_context, "Orders");
		public RoleRepository RoleRepository = new RoleRepository(database_context, "Roles");
		public SecurityRepository SecurityRepository = new SecurityRepository(database_context, "Security");
		public SoldVehicleRepository SoldVehicleRepository = new SoldVehicleRepository(database_context, "SoldVehicles");
		public UserRepository UserRepository = new UserRepository(database_context, "Users");
		public VehicleModelRepository VehicleModelRepository = new VehicleModelRepository(database_context, "VehicleModels");
		public VehicleRepository VehicleRepository = new VehicleRepository(database_context, "Vehicles");
		public VehicleTypeRepository VehicleTypeRepository = new VehicleTypeRepository(database_context, "VehicleTypes");
	}
}
