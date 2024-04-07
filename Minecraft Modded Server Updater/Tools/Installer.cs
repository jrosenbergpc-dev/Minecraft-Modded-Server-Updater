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
		/// <summary>
		/// Installs a Minecraft Mod File
		/// </summary>
		/// <param name="dir">PATH: Minecraft Mod Folder Directory</param>
		/// <param name="file">Mod File (path with filename allowed)</param>
		/// <returns></returns>
		public static bool InstallModFile(string dir, string file)
		{
			bool isDone = false;

			if (File.Exists(file))
			{
				try
				{
					File.Copy(file, dir + "//" + Path.GetFileName(file), true);
					isDone = true;
				}
				catch (Exception ex)
				{
				}
			}

			return isDone;
		}

		public static bool DoesDirectoryExist(string dir)
		{
			if (Directory.Exists(dir) == false)
			{
				Directory.CreateDirectory(dir);
			}

			return Directory.Exists(dir);
		}

		public static void CreateDownloadDirectory()
		{
			if (Directory.Exists(App.RunningDirectory + "\\tempdl") == false)
			{
				Directory.CreateDirectory(App.RunningDirectory + "\\tempdl");
			}
		}

		public static void CreateProfileDirectory()
		{
			if (Directory.Exists(App.RunningDirectory + "\\profiles") == false)
			{
				Directory.CreateDirectory(App.RunningDirectory + "\\profiles");
			}
		}

		/// <summary>
		/// Delete's a Specific file
		/// </summary>
		/// <param name="file">Filepath including filename</param>
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
