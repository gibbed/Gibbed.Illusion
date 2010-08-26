using System;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;
using Gibbed.Illusion.FileFormats;
using NDesk.Options;

namespace Gibbed.Illusion.DecompressSDS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool noWaitOnError = false;
            bool showHelp = false;

            OptionSet options = new OptionSet()
            {
                {
                    "nw|no-wait",
                    "don't wait for a key press on errors", 
                    v => noWaitOnError = v != null
                },

                {
                    "h|help",
                    "show this message and exit", 
                    v => showHelp = v != null
                },
            };

            List<string> extras;

            try
            {
                extras = options.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("{0}: ", GetExecutableName());
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `{0} --help' for more information.", GetExecutableName());
                return;
            }

            if (extras.Count < 1 || extras.Count > 2 || showHelp == true)
            {
                Console.WriteLine("Usage: {0} [OPTIONS]+ input_sds [output_sds]", GetExecutableName());
                Console.WriteLine("Decompress specified SDS archive.");
                Console.WriteLine();
                Console.WriteLine("Options:");
                options.WriteOptionDescriptions(Console.Out);
                return;
            }

            string inputPath = extras[0];
            string outputPath = extras.Count > 1 ? extras[1] : Path.ChangeExtension(inputPath, "_decompressed.sds");

            var archive = new FileFormats.SdsReader();
            archive.Open(inputPath);

            var data = new MemoryStream();
            archive.ExportData(data);
            data.Position = 0;

            using (var output = File.Open(outputPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                output.WriteStringASCII("SDS\0");
                output.WriteValueU32(19);
                output.WriteStringASCII("PC\0\0");
                output.WriteValueU32(0x5FFB74F3); // hash of header, doesn't need to be calculated

                var header = archive.Header;

                output.Seek(72, SeekOrigin.Begin);
                {
                    header.ResourceTypeTableOffset = (uint)output.Position;
                    output.WriteValueS32(archive.ResourceTypes.Count);
                    foreach (var resourceType in archive.ResourceTypes)
                    {
                        resourceType.Serialize(output, true);
                    }
                }

                header.BlockTableOffset = (uint)output.Position;

                output.WriteValueU32(0x6C7A4555);
                output.WriteValueU32((uint)data.Length);
                output.WriteValueU8(4);

                output.WriteValueU32((uint)data.Length);
                output.WriteValueU8(0);
                output.WriteFromStream(data, (uint)data.Length);

                output.WriteValueU32(0);
                output.WriteValueU8(0);

                header.XmlOffset = (uint)output.Position;
                output.WriteStringASCII(archive.Xml);

                output.Seek(16, SeekOrigin.Begin);

                var headerData = new MemoryStream();
                header.Serialize(headerData, true);
                output.WriteFromMemoryStreamSafe(headerData, true);
            }
        }

        private static string GetExecutableName()
        {
            return Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        }
    }
}
