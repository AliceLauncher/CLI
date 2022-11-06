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
    
    class ArgumentsJson
    {
        List<object> game { get; set; }
        List<object> jvm { get; set; }
    }

    internal partial class Arguments
    {




        // game arguments
        private string Username { get; set; }
        private string Version { get; set; }
        private string GameDir { get; set; }
        private string AssetsDir { get; set; }
        private string AssetIndex { get; set; }
        private string Uuid { get; set; }
        private string AccessToken { get; set; }
        private string ClientId { get; set; }
        private string Xuid { get; set; }
        private string UserType { get; set; }
        private string VersionType { get; set; }

        // not required if not custom
        private string Width { get; set; }
        private string Height { get; set; }

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
