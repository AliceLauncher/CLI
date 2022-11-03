using AliceCLI.Interfaces;

namespace AliceCLI.Authentication
{
    internal abstract class Authentication
    {
        public abstract string GetBaseURL();
        public virtual async Task<bool> Execute(HttpMethods methods, IRequest request)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage? response = null;

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            switch (methods)
            {
                case HttpMethods.GET:
                    response = await client.GetAsync(GetBaseURL());
                    break;
                case HttpMethods.POST:
                    Console.WriteLine("hi");
                    response = await client.PostAsync(GetBaseURL(), request.Payload());
                    break;
                case HttpMethods.PUT:
                    response = await client.PutAsync(GetBaseURL(), request.Payload());
                    break;
                case HttpMethods.DELETE:
                    response = await client.DeleteAsync(GetBaseURL());
                    break;   
            }

            if (response == null || !response.IsSuccessStatusCode)
                return false;

            return true;
        }

        private readonly string ContentType = "application/json";
    }
}