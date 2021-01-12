using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using DesktopApplication.Pages;

namespace DesktopApplication {
	public partial class MainWindow : Window {
		Page active;
		readonly Page starting = new Starting();
		readonly Page new_vehicle = new NewVehicle();
		readonly Page inventory = new Inventory();

		public MainWindow() {
			InitializeComponent();
			DataContext = this;
		}

		private void ChangePage(Page page) {
			active = page;
			MainFrame.Navigate(active);
		}

		private void OnLoad(object sender, RoutedEventArgs e) {
			ChangePage(starting);
		}

		private void OnClickStarting(object sender, MouseButtonEventArgs e) {
			ChangePage(starting);
		}

		private void OnClickNewVehicle(object sender, MouseButtonEventArgs e) {
			ChangePage(new_vehicle);
		}

        private void OnClickInventory(object sender, MouseButtonEventArgs e)
        {
			ChangePage(inventory);
		}
    }
}