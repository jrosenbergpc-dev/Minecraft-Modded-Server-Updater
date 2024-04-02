using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Modded_Server_Updater.Tools
{
	public static class Installer
	{
		public static bool InstallModFile(string file)
		{
			bool isDone = false;

			if (File.Exists(file))
			{
				try
				{
					File.Copy(file, App.MinecraftDirectory + "//" + Path.GetFileName(file), true);
					isDone = true;
				}
				catch (Exception ex)
				{
				}
			}

			return isDone;
		}

		public static void CreateDownloadDirectory()
		{
			if (Directory.Exists(App.RunningDirectory + "\\tempdl") == false)
			{
				Directory.CreateDirectory(App.RunningDirectory + "\\tempdl");
			}
		}

		public static void DeleteTempFile(string file)
		{
			try
			{
				File.Delete(file);
			}
			catch (Exception)
			{
			}
		}
	}
}
