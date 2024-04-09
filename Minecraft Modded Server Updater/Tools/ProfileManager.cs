using Minecraft_Modded_Server_Updater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Minecraft_Modded_Server_Updater.Tools
{
    public class ProfileManager
    {
        private List<ServerProfile> _profiles;
		private ProfileWriter _profileWriter;

        public ProfileManager() 
        {
			Downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
			Downloader.DownloadCompleted += Downloader_DownloadCompleted;
		}

        public List<ServerProfile> Profiles { get { return _profiles; } }

        public void CreateNewProfile(ServerProfile profile)
        {
			new ProfileWriter(profile).Save();
        }

        public void UpdateProfile()
        { 
        
        }

        public void DeleteProfile()
        {

        }

		public void LoadProfiles()
		{
			List<ServerProfile> tempProfiles = new List<ServerProfile>();

			if (Installer.DoesDirectoryExist(App.RunningDirectory + "//profiles"))
			{
				Directory.GetFiles(App.RunningDirectory + "//profiles").ToList().ForEach(file =>
				{
					tempProfiles.Add(new ProfileReader(file).Load());
				});
            }

			_profiles = tempProfiles;

        }

        public async void CheckProfiles()
        {
			_profiles.ForEach(async _profile =>
			{
				if (Installer.DoesDirectoryExist(_profile.InstallationPath))
				{
					if (Installer.DoesDirectoryExist(_profile.InstallationPath + "\\mods"))
					{
						if (_profile.IsActiveProfile == true)
						{
							List<Mod> xMods = await API.GetServerModList(_profile.RepositoryAddress);
							App.LastModList = xMods;

							API.ProcessModFiles(xMods, _profile.InstallationPath + "\\mods");
							API.VerifyAllMods(xMods, _profile.InstallationPath + "\\mods");

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
