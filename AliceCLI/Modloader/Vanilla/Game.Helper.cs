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
        public string id { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    class Client
    {
        public string argument { get; set; }
        public ClientFile file { get; set; }
        public string type { get; set; }
    }
    class Logging
    {
        public Client client { get; set; }
    }
    class DownloadsJson
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    class DownloadsLibraries
    {
        public DownloadsJson client { get; set; }
        public DownloadsJson client_mappings { get; set; }
        public DownloadsJson server { get; set; }
        public DownloadsJson server_mappings { get; set; }
    }
    class JavaVersion
    {
        public string component { get; set; }
        public int majorVersion { get; set; }
    }
    class AssetIndex
    {
        public string id { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public int totalSize { get; set; }
        public string url { get; set; }
    }
    class GameJson
    {
        public ArgumentsJson arguments { get; set; }
        public AssetIndex assetIndex { get; set; }
        public string assets { get; set; }
        public int complicanceLevel { get; set; }
        public DownloadsLibraries downloads { get; set; }
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
    class Os
    {
        public string name { get; set; }
    }

    class Rules
    {
        public string action { get; set; }
        public Os os { get; set; }
    }
    class Artifact
    {
        public string path { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    class DownloadsLibrariesJson
    {
        public Artifact artifact { get; set; }
    }

    class LibraryJson
    {
        public DownloadsLibrariesJson? downloads { get; set; }
        public string? name { get; set; }
        public List<Rules>? rules { get; set; }
    }
    class Latest
    {
        public string? release { get; set; }
        public string? snapshot { get; set; }
    }
    class Version
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public string url { get; set; }
        public string? time { get; set; }
        public string? releaseTime { get; set; }
    }

    class VersionsJson
    {
        public Latest? latest { get; set; }
        public List<Version>? versions { get; set; }
    }
}
