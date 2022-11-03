using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    class JavaVersion
    {
        string component { get; set; }
        int majorVersion { get; set; }
    }
    class AssetIndex
    {
        string id { get; set; }
        string sha1 { get; set; }
        int size { get; set; }
        int totalSize { get; set; }
    }
    class GameJson
    {
        //ArgumentsJson arguments { get; set; }
        public AssetIndex assetIndex { get; set; }
        public string assets { get; set; }
        public int complicanceLevel { get; set; }
        // downloads
        public string id { get; set; }
        public JavaVersion javaVersion { get; set; }
        public List<LibrariesJson> libraries { get; set; }
        // logging
        public string mainClass { get; set; }
        public int minimumLauncherVersion { get; set; }
        public string releaseTime { get; set; }
        public string time { get; set; }
        public string type { get; set; }
    }
}
