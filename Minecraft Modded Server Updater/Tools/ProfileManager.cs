using Minecraft_Modded_Server_Updater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Modded_Server_Updater.Tools
{
    public class ProfileManager
    {
        private List<ServerProfile> _profiles;
		private ProfileWriter _profileWriter = new ProfileWriter();

        public ProfileManager() 
        {
			Downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
			Downloader.DownloadCompleted += Downloader_DownloadCompleted;
		}

        public List<ServerProfile> Profiles { get { return _profiles; } }

        public void CreateNewProfile()
        {

        }

        public void UpdateProfile()
        { 
        
        }

        public void DeleteProfile()
        {

        }

        public async void CheckProfile()
        {
			_profiles.ForEach(async _profile =>
			{
				if (Installer.DoesDirectoryExist(_profile.InstallationPath))
				{
					if (Installer.DoesDirectoryExist(_profile.InstallationPath + "\\mods"))
					{
						List<Mod> xMods = await API.GetServerModList(_profile.RepositoryAddress);
						App.LastModList = xMods;

						xMods.ForEach(async mod =>
						{
							if (mod.IsInstalled == false)
							{
								await Task.Delay(500);

								if (await Downloader.DownloadModFile(_profile.RepositoryAddress, mod))
								{
									await Task.Delay(1000);

									if (Installer.InstallModFile(_profile.InstallationPath, App.RunningDirectory + "tempdl\\" + mod.FileName))
									{
										Installer.DeleteTempFile(App.RunningDirectory + "tempdl\\" + mod.FileName);
									}
								}
							}
						});
					}
				}
			});
        }

		//===============================================================================================//
		//===============================================================================================//
		//===============================================================================================//
		//PRIVATE STUFF
		//===============================================================================================//

		private void Downloader_DownloadCompleted(object? sender, bool e)
		{
			//if (e == false)
			//{
			//	StatusLabel.Content = "Download Failed!! Try Again!";
			//}
		}

		private void Downloader_DownloadProgressChanged(object? sender, int e)
		{
			//DownloadProgressBar.Value = e;
		}
	}
}
