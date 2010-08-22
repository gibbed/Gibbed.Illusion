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
                using (var input = File.Open("tables.sds", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    //Console.WriteLine(path);
                    var sds = new FileFormats.SdsFile();
                    sds.Deserialize(input);
                }
            }
        }
    }
}
