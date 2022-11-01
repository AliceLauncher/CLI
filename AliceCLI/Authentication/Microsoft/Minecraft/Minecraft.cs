namespace AliceCLI.Authentication.Microsoft.Minecraft
{
    /// <summary>
    /// https://wiki.vg/Microsoft_Authentication_Scheme
    /// </summary>
    internal class Minecraft : Authentication
    {
        public override string GetBaseURL()
        {
            return "https://api.minecraftservices.com/";
        }
    }
}