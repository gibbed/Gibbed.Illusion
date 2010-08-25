using System;
using System.Collections.Generic;
using System.IO;
using NDesk.Options;

namespace Gibbed.Illusion.DecryptSDS
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
                Console.WriteLine("Decrypt specified SDS archive.");
                Console.WriteLine();
                Console.WriteLine("Options:");
                options.WriteOptionDescriptions(Console.Out);
                return;
            }

            string inputPath = extras[0];
            string outputPath = extras.Count > 1 ? extras[1] : Path.ChangeExtension(inputPath, "_decrypted.sds");

            using (var input = File.Open(inputPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                if (input.Length < (0x90 + 15))
                {
                    Console.WriteLine("File too small to be an encrypted SDS.");

                    if (noWaitOnError == false)
                    {
                        Console.ReadKey(true);
                    }
                }

                input.Seek(0x90, SeekOrigin.Begin);
                byte[] fsfh = new byte[15];
                input.Read(fsfh, 0, fsfh.Length);

                // "tables/fsfh.bin"
                if (FileFormats.FNV.Hash64(fsfh, 0, fsfh.Length) != 0x39DD22E69C74EC6F)
                {
                    Console.WriteLine("File does not appear to be an encrypted SDS.");

                    if (noWaitOnError == false)
                    {
                        Console.ReadKey(true);
                    }
                }

                // figure out which TEA settings we need

                input.Seek(0x10000, SeekOrigin.Begin);

                uint[] keys = new uint[] { 0x73766E46, 0x6D454D5A, 0x336A6D68, 0x38425072 };
                TeaSetup setup = null;
                TeaSetup[] setups = new TeaSetup[]
                {
                    new TeaSetup(0x79FB0B01, 0x4B989BCD, 5),
                    new TeaSetup(0xA62336C0, 0x9D3119B6, 32),
                };

                byte[] header = new byte[8];
                input.Read(header, 0, header.Length);

                byte[] decrypted = new byte[8];
                foreach (var current in setups)
                {
                    Array.Copy(header, decrypted, header.Length);
                    FileFormats.TEA.Decrypt(decrypted, 0, 8, keys, current.Sum, current.Delta, current.Rounds);

                    if (BitConverter.ToUInt32(decrypted, 0) == 0x00534453)
                    {
                        setup = current;
                        break;
                    }
                }

                if (setup == null)
                {
                    Console.WriteLine("Don't know the TEA settings to decrypt this SDS.");

                    if (noWaitOnError == false)
                    {
                        Console.ReadKey(true);
                    }
                }

                input.Seek(0x10000, SeekOrigin.Begin);
                using (var output = File.Open(outputPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    long left = input.Length - input.Position;
                    byte[] data = new byte[0x4000];
                    while (left > 0)
                    {
                        int block = (int)(Math.Min(left, data.Length));
                        input.Read(data, 0, block);
                        FileFormats.TEA.Decrypt(data, 0, block, keys, setup.Sum, setup.Delta, setup.Rounds);
                        output.Write(data, 0, block);
                        left -= block;
                    }
                }
            }
        }

        private static string GetExecutableName()
        {
            return Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        }
    }
}
