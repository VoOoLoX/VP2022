using System;
using System.Linq;
using System.Collections.Generic;
using DataLayer;
using Shared;

namespace BusinessLayer {
	public static class UserBusiness {
		public static List<User> GetAll() => Repositories.UserRepository.GetAll();

		public static User Get(string email, string password) => GetAll().FirstOrDefault(user => user.Email == email && user.Password == password);

		public static User Get(string email) => GetAll().FirstOrDefault(user => user.Email == email);

		public static bool UserExists(string email) => GetAll().Exists(user => user.Email == email);

		public static bool Insert(User user) => Repositories.UserRepository.Insert(user);
	}
}
