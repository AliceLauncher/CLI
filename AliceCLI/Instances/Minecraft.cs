namespace AliceCLI.Instances
{
    internal class Minecraft
    {
        private string Version { get; set; }
        private Modloaders Modloader { get; set; }
        private string ModloaderVersion { get; set; }
        private List<string> Mods { get; set; }
        private int LastLaunch { get; set; }
        private int TotalTime { get; set; }
    }
}