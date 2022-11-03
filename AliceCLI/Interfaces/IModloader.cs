using System.Text.Json;

namespace AliceCLI.Interfaces
{
    internal interface IModloader
    {
        string URL();
        Task<bool> Download();
        
        void Play(string version)
        {

        }
    }
}