using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	public partial class SidebarButton : UserControl {
		public SidebarButton() {
			InitializeComponent();
			DataContext = this;
		}

		public static readonly DependencyProperty ImageSouceProperty = DependencyProperty.Register(
			"ImageSouce",
			typeof(string),
			typeof(SidebarButton),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string ImageSouce {
			get { return (string)GetValue(ImageSouceProperty); }
			set { SetValue(ImageSouceProperty, value); }
		}

		public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
			"Text",
			typeof(string),
			typeof(SidebarButton),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

		public string Text {
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
	}
}
