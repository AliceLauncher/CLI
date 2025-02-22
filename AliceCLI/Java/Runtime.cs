﻿namespace AliceCLI.Java
{
    /// <summary>
    /// https://api.adoptium.net/v3/binary/latest/{feature_version}/{release_type}/{os}/{arch}/{image_type}/{jvm_impl}/{heap_size}/{vendor}
    /// https://api.adoptium.net/v3/binary/latest/17/ga/windows/x64/jdk/hotspot/normal/eclipse
    /// </summary>
    internal class Runtime
    {
        public string OS { get; set; }

        public string Arch => System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString().ToLower();

        public string Version { get; set; }
        public string Path { get; set; }

        public Runtime(string version, string path)
        {
            Version = version;
            Path = path;
        }

        public async Task Download()
        {
            string url = $"https://api.adoptium.net/v3/binary/latest/{Version}/ga/{OS}/{Arch}/jre/hotspot/normal/eclipse";

            HttpClient client = new ();

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (!response.IsSuccessStatusCode)
            {
                url = $"https://api.adoptium.net/v3/binary/latest/{Version}/ga/{OS}/{Arch}/jdk/hotspot/normal/eclipse";
                response = client.GetAsync(url).Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Couldn't download Java {Version} JRE, skipping...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
            }

            var responseStream = await client.GetStreamAsync(url);

            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            using (var fileStream = new FileStream(Path + "/java", FileMode.Create))
            {
                responseStream.CopyTo(fileStream);
            }

            if (File.Exists(Path + "/java"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Downloaded!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (OS.Equals("windows"))
            {
                ExtractZip(Path + "/java", Path);
                File.Delete(Path + "/java");
            }
            else
            {
                ExtractTarGz(Path + "/java", Path);
                File.Delete(Path + "/java");
            }
        }
    }
}