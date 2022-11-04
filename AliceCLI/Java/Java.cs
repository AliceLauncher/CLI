using System.Runtime.InteropServices;

namespace AliceCLI.Java
{
    internal partial class Java
    {
        private string[] versions = { "8", "11", "16", "17" };

        private bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        private bool isLinux = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        private bool isOSX = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public async Task Exists()
        {
            foreach (var item in versions)
            {
                string os = "";
                if (isWindows)
                {
                    os = "windows";
                }
                else if (isLinux)
                {
                    os = "linux";
                }
                else if (isOSX)
                {
                    os = "mac";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Unsupported platform.");
                    Environment.Exit(1);
                }

                string path = $"{Environment.CurrentDirectory}/java/{os}/jre_{item}";

                if (!Directory.Exists(path))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Java {item} doesn't exist! Attempting to download.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    await Download(new Runtime(item, path));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Java {item} has been found!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        private async Task Download(Runtime jre)
        {
            if (isWindows)
            {
                jre.OS = "windows";
            }
            else if (isLinux)
            {
                jre.OS = "linux";
            }
            else if (isOSX)
            {
                jre.OS = "mac";
            }

            await jre.Download();
        }
    }
}