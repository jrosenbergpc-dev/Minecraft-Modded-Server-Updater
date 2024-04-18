using Minecraft_Modded_Server_Updater.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Minecraft_Modded_Server_Updater
{
	/// <summary>
	/// Interaction logic for CoreWindow.xaml
	/// </summary>
	public partial class CoreWindow : Window
	{
		private Main _MainWindow = new Main();

		public CoreWindow()
		{
			InitializeComponent();
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
			CoreFrame.Navigate(_MainWindow);
        }
    }
}
