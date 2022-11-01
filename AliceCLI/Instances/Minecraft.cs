using CLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Instances
{
    internal class Minecraft
    {
        string Version { get; set; }
        Modloaders Modloader { get; set; }
        string ModloaderVersion { get; set; }
        List<string> Mods { get; set; }
        int LastLaunch { get; set; }
        int TotalTime { get; set; }
    }
}
