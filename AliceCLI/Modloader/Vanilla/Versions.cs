using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    class Latest
    {
        public string Release { get; set; }
        public string Snapshot { get; set; }
    }
    class Version
    {
        string Id { get; set; }
        string Type { get; set; }
        string Url { get; set; }
    }
    internal class Versions
    {
        public Versions(string url)
        {

        }
    }
}
