using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    /// <summary>
    /// based of https://piston-meta.mojang.com/mc/game/version_manifest.json
    /// </summary>
    internal partial class Arguments
    {
        private string username { get; set; }
        private string version { get; set; }
        private string gameDir { get; set; }
        private string assetsDir { get; set; }
        private string aasetIndex { get; set; }
        private string uuid { get; set; }
        private string accessToken { get; set; }
        private string clientId { get; set; }
        private string xuid { get; set; }
        private string userType { get; set; }
        private string versionType { get; set; }

        // not required if not custom
        private string width { get; set; }
        private string height { get; set; }

        // jvm rules
        // windows
        string WindowsArgument = "-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump";
        string WindowsAbove10Argument = "\"-Dos.name=Windows 10\",\r\n                    \"-Dos.version=10.0\"";
        // osx
        string OsxArgument = "-XstartOnFirstThread";

        // every change placeholders
        string DefaultArgument = "\"-Djava.library.path=${natives_directory}\",\r\n            \"-Dminecraft.launcher.brand=${launcher_name}\",\r\n            \"-Dminecraft.launcher.version=${launcher_version}\",\r\n            \"-cp\",";
    }
}
