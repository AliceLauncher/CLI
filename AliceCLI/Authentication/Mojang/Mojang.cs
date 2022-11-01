namespace AliceCLI.Authentication.Mojang
{
    /// <summary>
    /// https://wiki.vg/Authentication#Authenticate
    /// </summary>
    internal class Mojang : Authentication
    {
        public override string GetBaseURL()
        {
            return "https://authserver.mojang.com";
        }
    }
}