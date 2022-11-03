using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
    internal class Versions
    {

        List<Version> versions = new List<Version>();
        Latest latest;

        public Versions(string url)
        {
            HttpClient client = new HttpClient();

            
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
