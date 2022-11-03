using System.Net.Http.Json;

namespace AliceCLI.Modloader.Vanilla
{

    internal partial class Versions
    {

        List<Version> versions = new();
        Latest latest = new();

        string BaseUrl { get; set; }

        public Versions(string url) => this.BaseUrl = url;

        public async Task Parse()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetFromJsonAsync<VersionsJson>(BaseUrl);
            versions = result.versions;
            latest = result.latest;
        }

        public Version GetVersion(string id) => versions.FirstOrDefault(x => x.id == id);
        public List<Version> GetVersions() => versions;
        public List<Version> GetReleaseVersions() => versions.FindAll(x => x.type == "release");
        public List<Version> GetSnapshotVersions() => versions.FindAll(x => x.type == "snapshot");
        public Latest GetLatest() => latest;

    }
}
