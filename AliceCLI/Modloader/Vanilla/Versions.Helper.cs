using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    class Latest
    {
        public string? release { get; set; }
        public string? snapshot { get; set; }
    }
    class Version
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public string? url { get; set; }
        public string? time { get; set; }
        public string? releaseTime { get; set; }
    }

    class VersionsJson
    {
        public Latest? latest { get; set; }
        public List<Version>? versions { get; set; }
    }
}
