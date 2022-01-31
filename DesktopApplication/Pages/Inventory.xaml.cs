using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessLayer;
using Shared;

namespace DesktopApplication.Pages {
	public partial class Inventory : Page {
		public class VehicleCardData {
			public int CardID { get; set; }
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
		private List<VehicleCardData> GetVehicleCards() {
			return VehicleBusiness.GetAllAvailable().Select(v => new VehicleCardData {
				CardID = v.ID,
				ImageSource = ImageUtils.GetImgurImages(VehicleBusiness.GetImage(v).Link).Data.FirstOrDefault().Link,
				FullName = $"{VehicleBusiness.GetManufacturer(v).Name} {VehicleBusiness.GetVehicleModel(v).Name}",
				Year = v.Year,
				Price = v.Price,
				Mileage = v.Mileage,
				HorsePower = v.HorsePower,
				Fuel = v.Fuel
			}).ToList();
		}

		private void OnLoad(object sender, RoutedEventArgs e) {
			InventoryItems.ItemsSource = GetVehicleCards();
		}

		private void VehicleCard_OnDeleteButton(int id) {
			var res = MessageBox.Show("Da li želite da obrišete ovo vozilo?", "Brisanje vozila", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (res == MessageBoxResult.Yes) {
				VehicleBusiness.Delete(VehicleBusiness.Get(id));
				InventoryItems.ItemsSource = GetVehicleCards();
			}
		}
	}
}
