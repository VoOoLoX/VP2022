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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApplication.Controls
{
    public partial class VehicleCard : UserControl
    {
        public VehicleCard()
        {
            InitializeComponent();
        }

		public event Action<int> OnDeleteButton;

		public static readonly DependencyProperty CardIDProperty = DependencyProperty.Register(
			"CardID",
			typeof(int),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public int CardID {
			get => (int)GetValue(CardIDProperty);
			set => SetValue(CardIDProperty, value);
		}

		public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
			"ImageSource",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string ImageSource {
			get => (string)GetValue(ImageSourceProperty);
			set => SetValue(ImageSourceProperty, value);
		}

		public static readonly DependencyProperty FullNameProperty = DependencyProperty.Register(
			"FullName",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string FullName {
			get => (string)GetValue(FullNameProperty);
			set => SetValue(FullNameProperty, value);
		}

		public static readonly DependencyProperty YearProperty = DependencyProperty.Register(
			"Year",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Year {
			get => (string)GetValue(YearProperty);
			set => SetValue(YearProperty, value);
		}

		public static readonly DependencyProperty MileageProperty = DependencyProperty.Register(
			"Mileage",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Mileage {
			get => (string)GetValue(MileageProperty);
			set => SetValue(MileageProperty, value);
		}

		public static readonly DependencyProperty HorsePowerProperty = DependencyProperty.Register(
			"HorsePower",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string HorsePower {
			get => (string)GetValue(HorsePowerProperty);
			set => SetValue(HorsePowerProperty, value);
		}

		public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
			"Type",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Type {
			get => (string)GetValue(TypeProperty);
			set => SetValue(TypeProperty, value);
		}

		public static readonly DependencyProperty FuelProperty = DependencyProperty.Register(
			"Fuel",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Fuel {
			get => (string)GetValue(FuelProperty);
			set => SetValue(FuelProperty, value);
		}

		public static readonly DependencyProperty PriceProperty = DependencyProperty.Register(
			"Price",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Price {
			get => (string)GetValue(PriceProperty);
			set => SetValue(PriceProperty, value);
		}

		private void DeleteButton(object sender, MouseButtonEventArgs e) => OnDeleteButton?.Invoke(CardID);
	}
}
