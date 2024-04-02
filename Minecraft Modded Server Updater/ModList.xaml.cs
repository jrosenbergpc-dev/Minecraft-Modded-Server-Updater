using Minecraft_Modded_Server_Updater.UI;
using System;
using System.Collections.Generic;
using System.IO;
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
using WinRT;

namespace Minecraft_Modded_Server_Updater
{
	/// <summary>
	/// Interaction logic for ModList.xaml
	/// </summary>
	public partial class ModList : Window
	{
		public ModList()
		{
			InitializeComponent();
		}

		private void GetModFileList()
		{
			ModListContainer.Children.Clear();

			if (App.LastModList != null )
			{
				App.LastModList.ForEach(mod =>
				{
					if (mod.IsInstalled == false)
					{
						ModListItem xItem = new ModListItem() { Type = ModType.NewMod, ModName = mod.FileName };
						ModListContainer.Children.Add(xItem);
					}
					else
					{
						ModListItem xItem = new ModListItem() { Type = ModType.Installed, ModName = mod.FileName };
						ModListContainer.Children.Add(xItem);
					}
				});
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			GetModFileList();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
        }
    }
}
