using AliceCLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    internal class Modloader : IModloader
    {
        public async Task<bool> Download()
        {
            new Versions(this.URL());



            return false;
        }

        public string URL() => "https://piston-meta.mojang.com/mc/game/version_manifest.json";
    }
}
