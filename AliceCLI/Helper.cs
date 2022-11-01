using ICSharpCode.SharpZipLib.Tar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI
{
    internal class Helper
    {
        public static void ExtractTar(string filename, string outputDir)
        {
            using (FileStream fsIn = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                TarInputStream tarIn = new TarInputStream(fsIn);
                TarEntry tarEntry;
                while ((tarEntry = tarIn.GetNextEntry()) != null)
                {
                    if (tarEntry.IsDirectory)
                        continue;

                    // Converts the unix forward slashes in the filenames to windows backslashes
                    string name = tarEntry.Name.Replace('/', Path.DirectorySeparatorChar);

                    // Remove any root e.g. '\' because a PathRooted filename defeats Path.Combine
                    if (Path.IsPathRooted(name))
                        name = name.Substring(Path.GetPathRoot(name).Length);

                    // Apply further name transformations here as necessary
                    string outName = Path.Combine(outputDir, name);

                    string directoryName = Path.GetDirectoryName(outName);

                    // Does nothing if directory exists
                    Directory.CreateDirectory(directoryName);

                    FileStream outStr = new FileStream(outName, FileMode.Create);

                    tarIn.CopyEntryContents(outStr);

                    outStr.Close();

                    // Set the modification date/time. This approach seems to solve timezone issues.
                    DateTime myDt = DateTime.SpecifyKind(tarEntry.ModTime, DateTimeKind.Utc);
                    File.SetLastWriteTime(outName, myDt);
                }

                tarIn.Close();
            }
        }
        public static void ExtractTarGz(string filename, string outputDir)
        {
            ExtractGzip(filename, filename + ".tar");

            ExtractTar(filename, outputDir);

            File.Delete(filename + ".tar");

        }
        public static async Task ExtractGzip(string filename, string outputDir)
        {
            using (var input = File.OpenRead(filename))
            using (var output = File.OpenWrite(outputDir))
            using (var gz = new GZipStream(input, CompressionMode.Decompress))
            {
                await gz.CopyToAsync(output);
            }
        }
        public static void ExtractZip(string filename, string outputDir)
        {
            ZipFile.ExtractToDirectory(filename, outputDir);
        }
    }
}
