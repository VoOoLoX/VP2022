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

namespace DesktopApplication.Pages
{
    public partial class SoldVehicles : Page
    {
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
		public SoldVehicles()
        {
            InitializeComponent();
        }

		private List<VehicleCardData> GetVehicleCards() {
			return SoldVehicleBusiness.GetAll().Select(v => new VehicleCardData {
				CardID = v.ID,
				ImageSource = ImageUtils.GetImgurImages(VehicleBusiness.GetImage(VehicleBusiness.Get(v.VehicleID)).Link).Data.FirstOrDefault().Link,
				FullName = $"{VehicleBusiness.GetManufacturer(VehicleBusiness.Get(v.VehicleID)).Name} {VehicleBusiness.GetVehicleModel(VehicleBusiness.Get(v.VehicleID)).Name}",
				Year = VehicleBusiness.Get(v.VehicleID).Year,
				Price = VehicleBusiness.Get(v.VehicleID).Price,
				Mileage = VehicleBusiness.Get(v.VehicleID).Mileage,
				HorsePower = VehicleBusiness.Get(v.VehicleID).HorsePower,
				Fuel = VehicleBusiness.Get(v.VehicleID).Fuel
			}).ToList();
		}

		private void OnLoad(object sender, RoutedEventArgs e) {
			InventoryItems.ItemsSource = GetVehicleCards();
		}

		private void VehicleCard_OnDeleteButton(int id) {
			var res = MessageBox.Show("Da li želite da obrišete ovo vozilo?", "Brisanje vozila", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if(res == MessageBoxResult.Yes) {
				VehicleBusiness.Delete(VehicleBusiness.Get(id));
				InventoryItems.ItemsSource = GetVehicleCards();
			}
		}
	}
}
