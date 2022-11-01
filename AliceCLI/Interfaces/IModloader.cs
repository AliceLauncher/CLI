using System.Text.Json;

namespace AliceCLI.Interfaces
{
    internal interface IModloader
    {
        string URL();

        JsonSerializer Deserialize();
    }
}