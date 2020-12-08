using System;
using System.Collections.Generic;
using System.Text;

namespace Shared {
	public class SoldVehicle {
		public int ID { get; set; }
		public DateTime Date { get; set; }
		public int VehicleID { get; set; }
		public int UserID { get; set; }
		public int OrderID { get; set; }
	}
}
