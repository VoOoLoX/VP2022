using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared;

namespace BusinessLayer {
	public static class SecurityBusiness {
		public static List<Security> GetAll() => Repositories.Instance.SecurityRepository.GetAll();

		public static Security Get(int id) => GetAll().FirstOrDefault(security => security.ID == id);

		public static int Insert(Security security) => Repositories.Instance.SecurityRepository.InsertGetID(security);
	}
}
