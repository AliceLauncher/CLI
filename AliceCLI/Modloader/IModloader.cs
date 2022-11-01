using System.Text.Json;

namespace AliceCLI.Modloader
{
    internal interface IModloader
    {
        string URL();

        JsonSerializer Deserialize();
    }
}