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
	public partial class InfoCard : UserControl
	{
		public InfoCard()
		{
			InitializeComponent();
			DataContext = this;
		}

		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
			"Value",
			typeof(string),
			typeof(InfoCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Value {
			get { return (string)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
			"Label",
			typeof(string),
			typeof(InfoCard),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Label {
			get { return (string)GetValue(LabelProperty); }
			set { SetValue(LabelProperty, value); }
		}

		public Brush BackgroundColor { get; set; } = Brushes.White;
		public Brush ValueColor { get; set; } = new SolidColorBrush(Color.FromRgb(6, 190, 182));
		public Brush LabelColor { get; set; } = Brushes.Black;
	}
}