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

		/// <summary>
		/// Create's Mod folder in specified Minecraft Directory.
		/// </summary>
		/// <param name="dir">Minecraft Directory (path)</param>
		public static void CreateModDirectory(string dir)
		{
			if (Directory.Exists(dir + "\\mods") == false)
			{
				Directory.CreateDirectory(dir + "\\mods");
			}
		}

		public static bool DoesDirectoryExist(string dir)
		{
			return Directory.Exists(dir);
		}

		public static void CreateDownloadDirectory()
		{
			if (Directory.Exists(App.RunningDirectory + "\\tempdl") == false)
			{
				Directory.CreateDirectory(App.RunningDirectory + "\\tempdl");
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
