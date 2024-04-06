using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Minecraft_Modded_Server_Updater.Models;

namespace Minecraft_Modded_Server_Updater.Tools
{
	public static class API
	{
		//public static string ServerAddress { get; set; } = "http://www.singularapplications.com/minecraft/servers/singularcore/mods/";

		public static async Task<List<Mod>> GetServerModList(Uri url)
		{
			//string = mod filename, bool = is installed or not
			List<Mod> modlist = new List<Mod>();

			//get stringdata from get url request here

			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode(); // Throw an exception if HTTP request fails

				string content = await response.Content.ReadAsStringAsync();
				// Split the content by new line to get individual strings
				string[] stringArray = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				// Convert the array to a List<string>
				List<string> stringList = new List<string>(stringArray);

				stringList.ForEach(item =>
				{
					if (item != String.Empty)
					{
						modlist.Add(new Mod() { FileName = item, IsInstalled = false });
					}
				});
			}

			return modlist;
		}

		public static void ProcessModFiles(List<Mod> modlist, string dir)
		{
			//check all installed mod files and find ones that aren't in the mod list and delete them!
			IEnumerable<String> xFiles = Directory.EnumerateFiles(dir);
			foreach (String xFile in xFiles)
			{
				string tempFileName = Path.GetFileName(xFile);

				if (modlist.Where(mod => mod.FileName == tempFileName).Any())
				{
					//the mod is installed and is in the mod list!
					//good!
				}
				else
				{
					//we found a file thats not in the mod list!!!
					//bad file, delete it!
					try
					{
						File.Delete(xFile);
					}
					catch (Exception)
					{
					}
				}
			}
		}

		public static void VerifyAllMods(List<Mod> modlist, string dir)
		{
			foreach (Mod mod in modlist)
			{
				VerifyModInstallation(mod, dir);
			}
		}

		private static void VerifyModInstallation(Mod modfile, string dir = "")
		{
			//check our mod directory first and compare against list!
			IEnumerable<String> xFiles = Directory.EnumerateFiles(Path.GetDirectoryName(modfile.FileName) ?? dir);

			foreach (String xFile in xFiles)
			{
				string tempFileName = Path.GetFileName(xFile);

				if (tempFileName == modfile.FileName)
				{
					modfile.IsInstalled = true;
					break;
				}
			}

			return;
		}
	}
}
