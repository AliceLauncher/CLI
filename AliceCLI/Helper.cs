using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;

namespace AliceCLI
{
    internal class Helper
    {
        [Obsolete]
        public static void ExtractTarGz(string filename, string outputDir)
        {
            var stream = File.OpenRead(filename);
            TarArchive tarArchive = TarArchive.CreateInputTarArchive(stream);
            tarArchive.ExtractContents(outputDir);
            tarArchive.Close();
            stream.Close();
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
