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
		public string Text { get; set; }
	}
}