using System;
using System.Collections.Generic;
using System.Text;
using Shared;

namespace DataLayer {
	public abstract class DatabaseModel<T> {
		protected DatabaseContext DatabaseContext;
		protected string TableName;
		protected DatabaseModel(DatabaseContext database_context, string table_name) {
			DatabaseContext = database_context;
			TableName = table_name;
		}

		public List<T> GetAll() => DatabaseContext.GetAllFromTable<T>(TableName);
		public bool Insert(T item) => DatabaseContext.InsertIntoTable(TableName, item);
	}
}
