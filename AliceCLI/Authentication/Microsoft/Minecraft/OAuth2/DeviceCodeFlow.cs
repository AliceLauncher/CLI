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

        public DeviceCodeFlow()
        {
            
        }

        public async Task<string> Create()
        {
            app = MsalMinecraftLoginHelper.CreateDefaultApplicationBuilder("CLIENT-ID")
            .Build();

            var handler = new MsalMinecraftLoginHandler(app);
            try
            {
                session = await handler.LoginSilent();
            } catch (MsalUiRequiredException)
            {

            }
            return session.AccessToken;
        }

       
        }
    }
}