using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DesktopApplication.Pages {
	public partial class Starting : Page {
		public Starting() {
			InitializeComponent();
		}

		private void Refresh() {
			VehicleCount.Value = VehicleBusiness.GetAllAvailable().Count.ToString();
			SoldVehicleCount.Value = SoldVehicleBusiness.GetAll().Count.ToString();
			Profit.Value = $"{SoldVehicleBusiness.GetProfit()} €";
		}

		private void OnLoad(object sender, RoutedEventArgs e) {
			Refresh();
		}

		private void OnUnload(object sender, RoutedEventArgs e) {
			Debug.WriteLine("Starting unloaded");
		}
	}
}
