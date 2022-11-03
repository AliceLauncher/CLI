using System.Net.Http.Json;

namespace AliceCLI.Interfaces
{
    internal interface IRequest
    {
        string Endpoint();
        string Data();
        
        HttpContent Payload()
        {
            return JsonContent.Create(Data());
        }
    }
}