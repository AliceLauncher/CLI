using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    internal partial class Libraries
    {
        string BaseUrl { get; set; }
        public Libraries(string url)
        {
            this.BaseUrl = url;
        }

        public async void Download()
        {

        }
    }
}
