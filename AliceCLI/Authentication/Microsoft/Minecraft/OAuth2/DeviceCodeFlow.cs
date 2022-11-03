using CmlLib.Core.Auth;
using CmlLib.Core.Auth.Microsoft;
using CmlLib.Core.Auth.Microsoft.MsalClient;
using Microsoft.Identity.Client;

namespace AliceCLI.Authentication.Microsoft.Minecraft.OAuth2
{
    /// <summary>
    /// https://github.com/CmlLib/CmlLib.Core.Auth.Microsoft/wiki
    /// </summary>

    internal class DeviceCodeFlow
    {
        private IPublicClientApplication app;

        public DeviceCodeFlow(string clientID)
        {
            app = MsalMinecraftLoginHelper.CreateDefaultApplicationBuilder(clientID).Build();
        }

        public async Task<MSession> Create()
        {

            var handler = new LoginHandlerBuilder()
                .ForJavaEdition()
                .WithMsalOAuth(app, f => f.CreateDeviceCodeApi(result =>
                {
                    Console.WriteLine(result.Message);
                    return Task.CompletedTask;
                }))
                .Build();

            try
            {
                var sessionCache = await handler.LoginFromCache();
                return sessionCache.GameSession;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                var sessionCache = await handler.LoginFromOAuth();
                return sessionCache.GameSession;
            }

        }
    }
}