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

		public static readonly DependencyProperty ImageSouceProperty = DependencyProperty.Register(
			"ImageSouce",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string ImageSouce {
			get { return (string)GetValue(ImageSouceProperty); }
			set { SetValue(ImageSouceProperty, value); }
		}

		public static readonly DependencyProperty FullNameProperty = DependencyProperty.Register(
			"FullName",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string FullName {
			get { return (string)GetValue(FullNameProperty); }
			set { SetValue(FullNameProperty, value); }
		}

		public static readonly DependencyProperty YearProperty = DependencyProperty.Register(
			"Year",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Year {
			get { return (string)GetValue(YearProperty); }
			set { SetValue(YearProperty, value); }
		}

		public static readonly DependencyProperty MileageProperty = DependencyProperty.Register(
			"Mileage",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Mileage {
			get { return (string)GetValue(MileageProperty); }
			set { SetValue(MileageProperty, value); }
		}

		public static readonly DependencyProperty HorsePowerProperty = DependencyProperty.Register(
			"HorsePower",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string HorsePower {
			get { return (string)GetValue(HorsePowerProperty); }
			set { SetValue(HorsePowerProperty, value); }
		}

		public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
			"Type",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Type {
			get { return (string)GetValue(TypeProperty); }
			set { SetValue(TypeProperty, value); }
		}

		public static readonly DependencyProperty FuelProperty = DependencyProperty.Register(
			"Fuel",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Fuel {
			get { return (string)GetValue(FuelProperty); }
			set { SetValue(FuelProperty, value); }
		}

		public static readonly DependencyProperty PriceProperty = DependencyProperty.Register(
			"Price",
			typeof(string),
			typeof(VehicleCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Price {
			get { return (string)GetValue(PriceProperty); }
			set { SetValue(PriceProperty, value); }
		}
	}
}
