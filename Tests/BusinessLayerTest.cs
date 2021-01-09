using Microsoft.VisualStudio.TestTools.UnitTesting;
using MartinCostello.SqlLocalDb;
using Microsoft.Data.SqlClient;
using System;
using System.IO;
using Shared;
using BusinessLayer;

namespace Tests {
	[TestClass]
	public class BusinessLayerTest {
		static readonly string instance_name = "TestingInstance";
		static readonly string sql_file = "Tables.sql";

		static ISqlLocalDbInstanceInfo db_instance;
		static ISqlLocalDbInstanceManager db_manager;

		[TestInitialize]
		public void TestInitialize() {
			using var local_db = new SqlLocalDbApi();

			if (local_db.GetInstanceInfo(instance_name).Exists) {
				local_db.StopInstance(instance_name);
				local_db.DeleteInstance(instance_name);
			}

			db_instance = local_db.GetOrCreateInstance(instance_name);
			db_manager = db_instance.Manage();

			if (!db_instance.IsRunning) {
				db_manager.Start();
			}

			CreateDatabase();
		}

		private void CreateDatabase() {
			using var connection = db_instance.CreateConnection();

			Repositories.Instance.ConnectionString = connection.ConnectionString;

			connection.Open();

			var sql_code = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), sql_file));

			var create_query = new SqlCommand() {
				CommandText = sql_code,
				Connection = connection
			};

			create_query.ExecuteNonQuery();
		}

		[TestMethod]
		[DataRow("test@example.com", "password", (int)UserRoles.Customer, DisplayName = "test@example.com")]
		[DataRow("admin@carcompany.com", "hd*(H@!_(J!@_", (int)UserRoles.Admin, DisplayName = "admin@carcompany.com")]

		public void InsertUser(string email, string password, int role_id) {
			var result = UserBusiness.Insert(new User { Email = email, Password = password, RoleID = role_id });
			Assert.IsTrue(result);
		}

		[TestMethod]
		[DataRow("test@example.com", DisplayName = "test@example.com")]
		[DataRow("admin@carcompany.com", DisplayName = "admin@carcompany.com")]
		public void CheckIfUserExists(string email) {
			var result = UserBusiness.UserExists(email);
			Assert.IsTrue(result);
		}
	}
}
