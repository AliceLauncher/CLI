using CmlLib.Core.Auth;
using CmlLib.Core.Auth.Microsoft.MsalClient;
using Microsoft.Identity.Client;

namespace AliceCLI.Authentication.Microsoft.Minecraft.OAuth2
{
    /// <summary>
    /// https://github.com/CmlLib/CmlLib.Core.Auth.Microsoft/wiki
    /// </summary>

    internal class DeviceCodeFlow
    {
        MSession? session = null;

        private IPublicClientApplication app;

        public DeviceCodeFlow(string clientID)
        {
            app = MsalMinecraftLoginHelper.CreateDefaultApplicationBuilder(clientID).Build();
        }

        public async Task<string> Create()
        {

            var handler = new MsalMinecraftLoginHandler(app);
            try
            {
                session = await handler.LoginSilent();
            } 
            catch (MsalUiRequiredException)
            {
                session = await handler.LoginDeviceCode(result =>
                {
                    Console.WriteLine($"Code: {result.UserCode}, ExpiresOn: {result.ExpiresOn.LocalDateTime}");
                    Console.WriteLine(result.Message);
                    return Task.CompletedTask;
                });
            }
            return session.AccessToken;
        }
    }
}