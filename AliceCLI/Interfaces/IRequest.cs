namespace AliceCLI.Interfaces
{
    internal interface IRequest
    {
        string Endpoint();

        string Payload();
    }
}