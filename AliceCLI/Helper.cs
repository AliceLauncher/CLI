using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpCompress;
using SharpCompress.Archives.GZip;
using SharpCompress.Archives.Tar;

namespace AliceCLI
{
    internal class Helper
    {
        public static void ExtractTarGz(string filename, string outputDir)
        {
            ExtractGzip(filename, filename + ".tar");

            using (var archive = TarArchive.Open(filename.tar))
            {
                foreach (var item in archive.Entries)
                {
                    Console.WriteLine(item);
                }
                archive.ExtractAllEntries();
            }
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
