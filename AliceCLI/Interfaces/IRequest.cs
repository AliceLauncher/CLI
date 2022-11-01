namespace AliceCLI.Interfaces
{
    internal interface IRequest
    {
        string Endpoint();

        HttpContent Payload();
    }
}