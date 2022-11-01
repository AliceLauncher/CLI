namespace AliceCLI.Authentication
{
    internal abstract class Authentication
    {
        public abstract string GetBaseURL();

        private readonly string ContentType = "application/json";
    }
}