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

namespace DesktopApplication.Controls {
	public partial class CheckBox : UserControl {
		public CheckBox() {
			InitializeComponent();
			DataContext = this;
		}

		public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
			"Label",
			typeof(string),
			typeof(CheckBox),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Label {
			get { return (string)GetValue(LabelProperty); }
			set { SetValue(LabelProperty, value); }
		}

		public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(
			"IsChecked",
			typeof(bool),
			typeof(CheckBox),
			new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public bool IsChecked {
			get { return (bool)GetValue(IsCheckedProperty); }
			set { SetValue(IsCheckedProperty, value); }
		}
	}
}
