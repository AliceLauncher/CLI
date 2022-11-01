namespace AliceCLI.Instances
{
    // alicialauncher.config.json
    internal partial class Config
    {
        private string Name { get; set; }
        private Minecraft Instance { get; set; }
        private int Memory { get; set; }
        private Services Service { get; set; }
        private string Arguments { get; set; }

        //if set
        private string JavaPath { get; set; }
    }
}