using System;

namespace Minecraft_Modded_Server_Updater.Models
{
    public class ServerProfile
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        /// <summary>
        /// Typically used for the Minecraft Directory e.g: %appdata%/.minecraft
        /// </summary>
        public string InstallationPath { get; set; }

        public Uri ServerAddress { get; set; }

        public Uri RepositoryAddress { get; set; }

        public bool IsActiveProfile { get; set; }
    }
}
