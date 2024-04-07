using Minecraft_Modded_Server_Updater.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Minecraft_Modded_Server_Updater.Tools
{
	internal class ProfileWriter
	{
		private ServerProfile _profile;

		public ProfileWriter() 
		{ 
		
		}

		public ProfileWriter(ServerProfile profile)
		{
			_profile = profile;
		}

		public void SaveProfile()
		{
			if ( _profile != null )
			{
				JObject filecontent = new JObject();

				filecontent.Add("name", JToken.FromObject(_profile.Name));
				filecontent.Add("description", JToken.FromObject(_profile.Description));
				filecontent.Add("version", JToken.FromObject(_profile.Version));
				filecontent.Add("activeprofile", JToken.FromObject(_profile.IsActiveProfile));
				filecontent.Add("installpath", JToken.FromObject(_profile.InstallationPath));
				filecontent.Add("server_url", JToken.FromObject(_profile.ServerAddress));
				filecontent.Add("repo_url", JToken.FromObject(_profile.RepositoryAddress));
				filecontent.Add("lastsaved", JToken.FromObject(DateTime.Now.ToShortDateString()));

				int x = Directory.GetFiles(App.RunningDirectory + "//profiles").Count() + 1;

				File.WriteAllText(App.RunningDirectory + "//profiles//" + x + ".mcprofile", filecontent.ToString());
			}
		}
	}
}
