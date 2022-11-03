using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
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
}
