using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Java
{
    internal partial class Java
    {
        string[] versions = { "8", "11", "16", "17" };

        bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        bool isLinux = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        bool isOSX = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        JDK jdk;

        public Java()
        {
            Exists();
        }

        private void Exists()
        {
            foreach (var item in versions)
            {
                if (!Directory.Exists($"{Environment.CurrentDirectory}/runtime/windows/jdk_{item}"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Java {item} doesn't exist! Attempting to download.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Download(new JDK(item, $"{Environment.CurrentDirectory}/runtime/windows/jdk_{item}"));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Java {item} has been found!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        private void Download(JDK jdk)
        {
            if (isWindows)
            {
                jdk.OS = "windows";
            }
            else if (isLinux)
            {
                jdk.OS = "linux";
            }
            else if (isOSX)
            {
                jdk.OS = "mac";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Unsupported platform.");
                Environment.Exit(1);
            }

            jdk.Download();
        }
    }
}
