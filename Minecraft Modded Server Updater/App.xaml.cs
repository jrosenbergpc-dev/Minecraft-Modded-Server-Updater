﻿using Minecraft_Modded_Server_Updater.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
		public static string MinecraftDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\mods\\";
	}
}
