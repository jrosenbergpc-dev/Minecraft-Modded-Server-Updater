using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Modded_Server_Updater.Models
{
    public class ServerProfile
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string InstallationPath { get; set; }
        public Uri ServerAddress { get; set; }
        public Uri RepositoryAddress { get; set; }

    }
}
