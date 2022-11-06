using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    internal  class VanillaModloader : Modloader
    {
        public override string URL() => "https://piston-meta.mojang.com/mc/game/version_manifest.json";

        public override string Arguments() => new Arguments().GetArguments();

        public override async Task<bool> Download()
        {

            // check if exists

            var ver = new Versions(this.URL());
            await ver.Parse();

            var game = new Game(ver.GetVersion("1.18.2"));
            await game.Parse();
            await game.Download();
            return true;
        }
    }
}
