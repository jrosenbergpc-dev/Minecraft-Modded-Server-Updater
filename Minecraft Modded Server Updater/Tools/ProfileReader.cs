using Minecraft_Modded_Server_Updater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Minecraft_Modded_Server_Updater.Tools
{
    internal class ProfileReader
    {
        private String mcProfile;

        public ProfileReader()
        {

        }

        public ProfileReader(string file)
        {
            mcProfile = file;
        }

        public ServerProfile Load()
        {
            ServerProfile profile = null;



            return profile;
        }
    }
}
