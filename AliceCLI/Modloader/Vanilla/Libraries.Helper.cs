using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    class Os
    {
        string Name { get; set; }
    }

    class Rules
    {
        string Action { get; set; }
        Os Os { get; set; }
    }
    class Artifact
    {
        string Path { get; set; }
        string Sha1 { get; set; }
        int Size { get; set; }
        string Url { get; set; }
    }

    class Downloads
    {
        Artifact Artifact { get; set; }
        string Name { get; set; }
        List<Os>();
    }

    partial class Libraries
    {
        List<Downloads>();
    }
}
