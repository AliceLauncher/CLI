using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace AliceCLI.Authentication.Microsoft.Minecraft.OAuth2
{
    /// <summary>
    /// https://github.com/Azure-Samples/ms-identity-dotnet-desktop-tutorial/blob/master/4-DeviceCodeFlow/Console-DeviceCodeFlow-v2/Program.cs
    /// </summary>
    internal class DeviceCodeFlow
    {
        private static PublicClientApplicationOptions appConfiguration = null;

        private static IConfiguration configuration;

        private static IPublicClientApplication application;

        private string[] scopes = new[] { /*"user.read",*/"XboxLive.signin", "XboxLive.offline_access" };

        public DeviceCodeFlow()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            configuration = builder.Build();

            appConfiguration = configuration.Get<PublicClientApplicationOptions>();
        }

        public async Task<string> Create()
        {
            return await SignInUserAndGetTokenUsingMSAL(appConfiguration, scopes);
        }

        private static async Task<string> SignInUserAndGetTokenUsingMSAL(PublicClientApplicationOptions configuration, string[] scopes)
        {
            // build the AAd authority Url
            string authority = string.Concat(configuration.Instance, configuration.TenantId);

            // Initialize the MSAL library by building a public client application
            application = PublicClientApplicationBuilder.Create(configuration.ClientId)
                                                    .WithAuthority(authority)
                                                    .WithDefaultRedirectUri()
                                                    .Build();

            AuthenticationResult result;

            try
            {
                var accounts = await application.GetAccountsAsync();
                // Try to acquire an access token from the cache. If device code is required, Exception will be thrown.
                result = await application.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                result = await application.AcquireTokenWithDeviceCode(scopes, deviceCodeResult =>
                {
                    Console.WriteLine(deviceCodeResult.Message);
                    return Task.FromResult(0);
                }).ExecuteAsync();
            }
            return result.AccessToken;
        }
    }
}