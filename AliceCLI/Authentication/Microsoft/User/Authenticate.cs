using AliceCLI.Interfaces;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;
using System.Xml;

namespace AliceCLI.Authentication.Microsoft.User
{

/*
{
    "Properties": {
        "AuthMethod": "RPS",
        "SiteName": "user.auth.xboxlive.com",
        "RpsTicket": "d=<access token>" // your access token from the previous step here
    },
    "RelyingParty": "http://auth.xboxlive.com",
    "TokenType": "JWT"
}
*/

    class Properties
    {
        public string? AuthMethod { get; set; }
        public string? SiteName { get; set; }
        public string? RpsTicket { get; set; }
    }
    class PayloadFormat
    {
        public Properties Properties { get; set; }
        public string? RelyingParty { get; set; }
        public string? TokenType { get; set; }
    }
    internal class Authenticate : IRequest
    {
        string JWTToken;

        public Authenticate(string JWTToken) => this.JWTToken = JWTToken ?? throw new ArgumentNullException(nameof(JWTToken));

        public string Endpoint()
        {
            throw new NotImplementedException();
        }

        public HttpContent Payload()
        {

            Console.WriteLine(JsonSerializer.Serialize(
                new PayloadFormat
                {
                    Properties = new Properties
                    {
                        AuthMethod = "RPS",
                        SiteName = "user.auth.xboxlive.com",
                        RpsTicket = $"d={this.JWTToken}",
                    },
                    RelyingParty = "http://auth.xboxlive.com",
                    TokenType = "JWT",
                }
            ));

            return JsonContent.Create(JsonSerializer.Serialize(
                new PayloadFormat
                {
                    Properties = new Properties
                    {
                        AuthMethod = "RPS",
                        SiteName = "user.auth.xboxlive.com",
                        RpsTicket = $"d={this.JWTToken}",
                    },
                    RelyingParty = "http://auth.xboxlive.com",
                    TokenType = "JWT",
                }
            ));
        }
    }
}


