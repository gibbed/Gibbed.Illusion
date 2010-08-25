using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gibbed.Illusion.Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //foreach (string path in Directory.GetFiles(@"T:\Games\Steam\steamapps\common\mafia ii - public demo", "*.sds", SearchOption.AllDirectories))
            {
                //Console.WriteLine(path);
                var sds = new FileFormats.SdsReader();
                sds.Open("tables.sds");
            }

            /*
            using (var input = File.OpenRead("sdsconfig.bin"))
            {
                var config = new FileFormats.SdsConfigFile();
                config.Deserialize(input);
            }
            */
        }
    }
}
