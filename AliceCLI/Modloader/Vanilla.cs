using AliceCLI.Interfaces;

namespace AliceCLI.Modloader
{
    internal class Vanilla : IModloader
    {
        public string URL() => "https://piston-meta.mojang.com/mc/game/version_manifest.json";
        

    }
}