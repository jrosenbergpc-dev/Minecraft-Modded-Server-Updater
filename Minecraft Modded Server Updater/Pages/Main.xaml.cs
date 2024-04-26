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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minecraft_Modded_Server_Updater.Pages
{
	/// <summary>
	/// Interaction logic for Main.xaml
	/// </summary>
	public partial class Main : Page
	{
		public Main()
		{
			InitializeComponent();
		}

		public event EventHandler AddButtonClicked;
		public event EventHandler RemoveButtonClicked;

		private void AddButton_OnNavClicked(object sender, EventArgs e)
		{
			AddButtonClicked?.Invoke(this, e);
        }

		private void RemoveButton_OnNavClicked(object sender, EventArgs e)
		{
			RemoveButtonClicked?.Invoke(this, e);
		}
	}
}
