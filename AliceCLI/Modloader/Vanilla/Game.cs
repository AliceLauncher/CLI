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
        GameJson? game = new GameJson();
        string BaseUrl { get; set; }
        public Game(Version metadata) => BaseUrl = metadata.url;

        public async Task Parse()
        {
            HttpClient client = new HttpClient();
            
            game = await client.GetFromJsonAsync<GameJson>(BaseUrl);
        }

        public async Task Download()
        {
            foreach (var libs in game.libraries)
            {
                var file = libs.downloads.artifact;
                await new Library(file.url, $"{Environment.CurrentDirectory}/dts/libraries/{file.path}", file.sha1).Download();
                Console.WriteLine($"Downloading: {libs.name}");
            }
        }
    }
}
