using System.Text.Json;

namespace AliceCLI.Modloader
{
    internal abstract class Modloader
    {
        public abstract string URL();
        public abstract Task<bool> Download();
        // play instance 
        public void Play()
        {
            
        }
    }
}