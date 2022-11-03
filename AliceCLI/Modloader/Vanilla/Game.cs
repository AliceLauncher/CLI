using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    internal class Game
    {
        string BaseUrl { get; set; }
        public Game(Version metadata)
        {
            this.BaseUrl = metadata.url;
            
            Console.WriteLine(metadata.url);
        }

        public async Task Parse()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetFromJsonAsync<GameJson>(BaseUrl);
            Console.WriteLine(result?.ToString());
        }

        public async void Download()
        {
            Console.WriteLine("godzilla");
        }
    }
}
