using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;
using Shared;

namespace DesktopApplication.Pages {
	public partial class Inventory : Page {
		public class VehicleCard {
			public string ImageSource { get; set; }
			public string FullName { get; set; }
			public int Year { get; set; }
			public decimal Price { get; set; }
			public decimal Mileage { get; set; }
			public int HorsePower { get; set; }
			public string Fuel { get; set; }
		}
		public Inventory() {
			InitializeComponent();
		}

		private void OnLoad(object sender, RoutedEventArgs e) {
			InventoryItems.ItemsSource = VehicleBusiness.GetAllAvailable().Select(v => new VehicleCard {
				ImageSource = ImageUtils.GetImgurImages(VehicleBusiness.GetImage(v).Link).Data.FirstOrDefault().Link,
				FullName = $"{VehicleBusiness.GetManufacturer(v).Name} {VehicleBusiness.GetVehicleModel(v).Name}",
				Year = v.Year,
				Price = v.Price,
				Mileage = v.Mileage,
				HorsePower = v.HorsePower,
				Fuel = v.Fuel
			}).ToList();
		}
	}
}
