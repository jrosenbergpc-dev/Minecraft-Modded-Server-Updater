using Minecraft_Modded_Server_Updater.Models;
using Minecraft_Modded_Server_Updater.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Minecraft_Modded_Server_Updater
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
			Downloader.DownloadCompleted += Downloader_DownloadCompleted;
		}

		private void Downloader_DownloadCompleted(object? sender, bool e)
		{
			if (e == false)
			{
				StatusLabel.Content = "Download Failed!! Try Again!";
			}
		}

		private void Downloader_DownloadProgressChanged(object? sender, int e)
		{
			DownloadProgressBar.Value = e;
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			StatusLabel.Content = "Checking Installation...";
			Installer.CreateDownloadDirectory();

			if (App.MinecraftDirectory != null)
			{
				ModCountLabel.Content = "[Installed Mods: " + System.IO.Directory.GetFiles(App.MinecraftDirectory).Count() + "]";
			}

			StatusLabel.Content = "Getting Mod List from Server...";
			List<Mod> xMods = await API.GetServerModList();
			App.LastModList = xMods;

			await Task.Delay(1000);

			StatusLabel.Content = "Verifying Installed Mods...";
			await Task.Delay(500);

			bool bComplete = false;

			foreach (Mod mod in xMods)
			{
				if (mod.IsInstalled == false)
				{
					StatusLabel.Content = "Downloading New Mod...";
					DownloadProgressBar.Value = 0;
					DownloadProgressBar.Visibility = Visibility.Visible;
					//download the mod file from server!
					await Task.Delay(500);

					if (await Downloader.DownloadModFile(mod))
					{
						StatusLabel.Content = "Mod Downloaded! Installing Mod...";
						//install it!
						await Task.Delay(1000);

						if (Installer.InstallModFile(App.RunningDirectory + "tempdl\\" + mod.FileName))
						{
							Installer.DeleteTempFile(App.RunningDirectory + "tempdl\\" + mod.FileName);

							DownloadProgressBar.Visibility = Visibility.Collapsed;
							StatusLabel.Content = "New Mod Installed!";
							await Task.Delay(500);

							if (App.MinecraftDirectory != null)
							{
								ModCountLabel.Content = "[Installed Mods: " + System.IO.Directory.GetFiles(App.MinecraftDirectory).Count() + "]";
							}
						}
					}
				}
			}

			bComplete = true;

			if (bComplete == true)
			{
				StatusLabel.Content = "All Mods Verified!";
				await Task.Delay(1000);

				StatusImage.Visibility = Visibility.Collapsed;
				StatusImageGood.Visibility = Visibility.Visible;

				StatusLabel.Content = "All Mods Installed! Ready to Play!";
				await Task.Delay(500);
				StartButton.Visibility = Visibility.Visible;
			}
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			if (System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Minecraft"))
			{
				//Minecraft Launcher Exists!
				Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Minecraft\\MinecraftLauncher.exe");
				this.Close();
			}
			else if (System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Minecraft"))
			{
				Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Minecraft\\MinecraftLauncher.exe");
				this.Close();
			}
			else if (System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Minecraft Launcher"))
			{
				Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Minecraft Launcher\\MinecraftLauncher.exe");
				this.Close();
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ModList mWindow = new ModList();
			mWindow.ShowDialog();
		}
	}
}
