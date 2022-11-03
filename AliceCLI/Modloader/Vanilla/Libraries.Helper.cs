using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    class Os
    {
        string name { get; set; }
    }

    class Rules
    {
        string action { get; set; }
        Os os { get; set; }
    }
    class Artifact
    {
        string path { get; set; }
        string sha1 { get; set; }
        int size { get; set; }
        string url { get; set; }
    }

    class Downloads
    {
        Artifact artifact { get; set; }
        string name { get; set; }
        List<Os> os { get; set; }
    }

    class LibrariesJson
    {
        List<Downloads> downloads { get; set; }
        string name { get; set; }
        List<Rules> rules { get; set; }
    }
}
