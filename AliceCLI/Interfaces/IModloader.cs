using System.Text.Json;

namespace AliceCLI.Interfaces
{
    internal interface IModloader
    {
        string URL();

        Task<bool> Download()
        {
            HttpClient client = new HttpClient();
            return null;
        }
    }
}