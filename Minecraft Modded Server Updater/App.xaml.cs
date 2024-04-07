using Minecraft_Modded_Server_Updater.Models;
using Minecraft_Modded_Server_Updater.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Minecraft_Modded_Server_Updater
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		//Rename application to MC Copilot or Modded Minecraft Copilot or something like this maybe??
		public static List<Mod> LastModList { get; set; }
		public static string RunningDirectory { get; set; } = AppContext.BaseDirectory;
		//public static string MinecraftDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\mods\\";

		protected override void OnStartup(StartupEventArgs e)
		{
			Installer.CreateDownloadDirectory();
			Installer.CreateProfileDirectory();

			base.OnStartup(e);
		}

		protected override void OnLoadCompleted(NavigationEventArgs e)
		{
			base.OnLoadCompleted(e);
		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
		}
	}
}
