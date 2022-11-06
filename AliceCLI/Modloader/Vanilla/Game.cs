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
                // os filtering
                if (libs.rules is not null)
                {
                    foreach (var item in libs.rules)
                    {
                        // check for os helper etc
                    }
                }
                await new Dts(file.url, file.path, "libraries").Download();
            }

            await new Dts(game.assetIndex.url, $"indexes/{game.assetIndex.id}.json", "assets").Download();
            await new Dts(game.logging.client.file.url, $"log_configs/{game.logging.client.file.id}", "assets").Download();
            await new Dts(game.downloads.client.url, $"{game.id}/{game.id}.jar", "versions").Download();
            await new Dts(BaseUrl, $"{game.id}/{game.id}.json", "versions").Download();

        }
    }
}
