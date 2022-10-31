using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Java
{
    /// <summary>
    /// https://api.adoptium.net/v3/binary/latest/{feature_version}/{release_type}/{os}/{arch}/{image_type}/{jvm_impl}/{heap_size}/{vendor}
    /// https://api.adoptium.net/v3/binary/latest/17/ga/windows/x64/jdk/hotspot/normal/eclipse
    /// </summary>
    internal class JDK
    {
        public string OS { get; set; }
        public string Arch 
        {
            get => System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString().ToLower();
        }
        public string Version { get; set; }
        public string Path { get; set; }

        public JDK(string version, string path)
        {
            Version = version;
            Path = path;
        }

        public void Download()
        {
            string url = $"https://api.adoptium.net/v3/binary/latest/{Version}/ga/{OS}/{Arch}/jdk/hotspot/normal/eclipse";

            HttpClient client = new HttpClient();
            
            var responseStream = client.GetStreamAsync(url);

            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            using var fileStream = new FileStream(Path + "/java", FileMode.Create);
            responseStream.Result.CopyTo(fileStream);

            if (File.Exists(Path + "/java"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Downloaded!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
