using System;
using System.Collections.Generic;
using System.Text;
using Shared;

namespace DataLayer {
	public class OrderRepository : DatabaseModel<Order> {
		public OrderRepository(DatabaseContext database_context, string table_name)
			: base(database_context, table_name) { }

	}
}
