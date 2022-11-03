using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    class Latest
    {
        public string Release { get; set; }
        public string Snapshot { get; set; }
    }
    class Version
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Time { get; set; }
        public string ReleaseTime { get; set; }
    }

    internal class Versions
    {

        List<Version> versions = new List<Version>();
        Latest latest;

        string BaseUrl { get; set; }

        public Versions(string url) => this.BaseUrl = url;

        public async void Parse()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(BaseUrl);

            JsonSerializer.Deserialize<Version>(result.Content.ToString());
        }

        public Version GetVersion(string id)
        {
            return versions.Find(x => x.Id.Equals(id));
        }

        public List<Version> GetVersions()
        {
            return versions;
        }
        public List<Version> GetReleaseVersions()
        {
            return versions.FindAll(x => x.Type == "release");
        }

        public List<Version> GetSnapshotVersions()
        {
            return versions.FindAll(x => x.Type == "snapshot");
        }

        public Latest GetLatest()
        {
            return latest;
        }
    
    }
}
