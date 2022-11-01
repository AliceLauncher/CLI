using CLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Instances
{
    // alicialauncher.config.json
    internal partial class Config
    {
        string Name { get; set; }
        Minecraft Instance { get; set; }
        int Memory { get; set; }
        Services Service { get; set; }
        string Arguments { get; set; }
        //if set
        string JavaPath { get; set; } 
    }
}
