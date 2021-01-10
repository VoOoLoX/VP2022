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
		public string Value { get; set; }
		public string Label { get; set; }
		public Brush BackgroundColor { get; set; } = Brushes.White;
		public Brush ValueColor { get; set; } = new SolidColorBrush(Color.FromRgb(6, 190, 182));
		public Brush LabelColor { get; set; } = Brushes.Black;
	}
}