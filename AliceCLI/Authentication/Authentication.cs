namespace AliceCLI.Authentication
{
    internal abstract class Authentication
    {
        public abstract string GetBaseURL();
        public abstract HttpContent GetPayload();
        public virtual async Task<bool> Execute(HttpMethods methods)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage? response = null;

            switch (methods)
            {
                case HttpMethods.GET:
                    response = await client.GetAsync(GetBaseURL());
                    break;
                case HttpMethods.POST:
                    response = await client.PostAsync(GetBaseURL(), GetPayload());
                    break;
                case HttpMethods.PUT:
                    response = await client.PutAsync(GetBaseURL(), GetPayload());
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