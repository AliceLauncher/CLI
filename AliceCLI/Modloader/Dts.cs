using AliceCLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader
{
    internal class Dts
    {
        public string BaseUrl { get; }
        public string SavePath { get; set; }
        public string ParentFolder { get; }
        public string Sha1 { get; }
        public Dts(string url, string path, string parentFolder = null, string sha1 = null)
        {
            BaseUrl = url;
            SavePath = path;
            ParentFolder = parentFolder;
            Sha1 = sha1;
        }
        public Dts(string url, string path, string parentFolder = null)
        {
            BaseUrl = url;
            SavePath = path;
            ParentFolder = parentFolder;
        }

        public async Task Download()
        {

            if (!string.IsNullOrEmpty(ParentFolder))
            {
                SavePath = $"{Environment.CurrentDirectory}/dts/{ParentFolder}/{SavePath}";
            }

            HttpClient client = new HttpClient();
            var responseStream = await client.GetStreamAsync(BaseUrl);

            Directory.CreateDirectory(Path.GetFullPath(Path.Combine(SavePath, @"..\")));
            using (var fileStream = new FileStream(SavePath, FileMode.Create))
            {
                responseStream.CopyTo(fileStream);
            }
            if (!string.IsNullOrEmpty(Sha1))
            {
                
            }
        }
    }
}
