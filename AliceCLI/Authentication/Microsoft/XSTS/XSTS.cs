namespace AliceCLI.Authentication.Microsoft.XSTS
{
    internal class XSTS : Authentication
    {
        public override string GetBaseURL()
        {
            return "https://xsts.auth.xboxlive.com/";
        }

        public override HttpContent GetPayload()
        {
            throw new NotImplementedException();
        }
    }
}