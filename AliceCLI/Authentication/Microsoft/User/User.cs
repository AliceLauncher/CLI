namespace AliceCLI.Authentication.Microsoft.User
{
    internal class User : Authentication
    {
        public override string GetBaseURL()
        {
            return "https://xsts.auth.xboxlive.com/";
        }
    }
}