using System;
using System.Linq;
using System.Collections.Generic;
using DataLayer;
using Shared;

namespace BusinessLayer {
	public static class OrderBusiness {
		public static List<Order> GetAll() => Repositories.Instance.OrderRepository.GetAll();

		public static Order Get(int id) => GetAll().FirstOrDefault(order => order.ID == id);

		public static int Insert(Order order) => Repositories.Instance.OrderRepository.InsertGetID(order);
	}
}
