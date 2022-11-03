using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    class ClientFile
    {
        string id { get; set; }
        string sha1 { get; set; }
        int size { get; set; }
        string url { get; set; }
    }
    class Client
    {
        string argument { get; set; }
        ClientFile file { get; set; }
        string type { get; set; }
    }
    class Logging
    {
        Client client { get; set; }
    }
    class DownloadsJson
    {
        string sha1 { get; set; }
        int size { get; set; }
        string url { get; set; }
    }
    class DownloadsLibraries
    {
        DownloadsJson client { get; set; }
        DownloadsJson client_mappigs { get; set; }
        DownloadsJson server { get; set; }
        DownloadsJson server_mappings { get; set; }
    }
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
        public ArgumentsJson arguments { get; set; }
        public AssetIndex assetIndex { get; set; }
        public string assets { get; set; }
        public int complicanceLevel { get; set; }
        public DownloadsJson downloads { get; set; }
        public string id { get; set; }
        public JavaVersion javaVersion { get; set; }
        public List<LibraryJson> libraries { get; set; }
        public Logging logging { get; set; }
        public string mainClass { get; set; }
        public int minimumLauncherVersion { get; set; }
        public string releaseTime { get; set; }
        public string time { get; set; }
        public string type { get; set; }
    }
}
