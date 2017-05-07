/* Copyright (c) 2017 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NDesk.Options;

namespace Gibbed.Mafia2.FrameExport
{
    internal class Program
    {
        private static string GetExecutableName()
        {
            return Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        }

        public static void Main(string[] args)
        {
            bool showHelp = false;

            OptionSet options = new OptionSet()
            {
                { "h|help", "show this message and exit", v => showHelp = v != null },
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
                Console.WriteLine("Usage: {0} [OPTIONS]+ input_sds [output]", GetExecutableName());
                Console.WriteLine();
                Console.WriteLine("Options:");
                options.WriteOptionDescriptions(Console.Out);
                return;
            }

            string inputPath = extras[0];
            string outputPath = extras.Count > 1 ? extras[1] : (Path.ChangeExtension(inputPath, null) + ".bin");

            FileFormats.ArchiveFile archiveFile;
            using (var input = File.OpenRead(inputPath))
            using (Stream data = FileFormats.ArchiveEncryption.Unwrap(input))
            {
                archiveFile = new FileFormats.ArchiveFile();
                archiveFile.Deserialize(data ?? input);
            }
            var endian = archiveFile.Endian;

            var frameResourceTypeIndex = archiveFile.ResourceTypes.FindIndex(rt => rt.Name == "FrameResource");
            if (frameResourceTypeIndex < 0)
            {
                Console.WriteLine("This archive does not have any frame resource data.");
                return;
            }

            var frameResourceType = archiveFile.ResourceTypes[frameResourceTypeIndex];
            var frameResources = archiveFile.ResourceEntries.Where(re => re.TypeId == frameResourceType.Id).ToArray();
            if (frameResources.Length == 0)
            {
                Console.WriteLine("There are no frame resources.");
                return;
            }

            foreach (var frameEntry in frameResources)
            {
                using (var data = new MemoryStream(frameEntry.Data, false))
                {
                    var frame = new ResourceFormats.FrameResource();
                    frame.Deserialize(frameEntry.Version, data, endian);
                }
            }
            throw new NotImplementedException();
        }
    }
}
