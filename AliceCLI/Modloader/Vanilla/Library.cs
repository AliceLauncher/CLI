using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    internal partial class Library
    {
        string BaseUrl { get; }
        public string SavePath { get; }
        public string Sha1 { get; }

        public Library(string url, string path, string sha1)
        {
            BaseUrl = url;
            SavePath = path;
            Sha1 = sha1;
        }

        public async Task Download()
        {
            HttpClient client = new HttpClient();
            var responseStream = await client.GetStreamAsync(BaseUrl);

            Directory.CreateDirectory(Path.GetFullPath(Path.Combine(SavePath, @"..\")));
            using (var fileStream = new FileStream(SavePath, FileMode.Create))
            {
                responseStream.CopyTo(fileStream);
            }
        }
    }
}
