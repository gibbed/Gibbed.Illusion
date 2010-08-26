using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats
{
    public static class StreamHelpers
    {
        public static MemoryStream ReadToMemoryStreamSafe(this Stream stream, long size, bool littleEndian)
        {
            MemoryStream memory = new MemoryStream();

            uint myHash = FNV.InitialHash32;

            long left = size;
            byte[] buffer = new byte[4096];
            while (left > 0)
            {
                int block = (int)(Math.Min(left, 4096));
                stream.Read(buffer, 0, block);
                myHash = FNV.Hash32(buffer, 0, block);
                memory.Write(buffer, 0, block);
                left -= block;
            }

            var theirHash = stream.ReadValueU32(littleEndian);
            if (theirHash != myHash)
            {
                throw new InvalidDataException(string.Format("hash failure ({0:X} vs {1:X})",
                    myHash, theirHash));
            }

            memory.Position = 0;
            return memory;
        }

        public static void WriteFromMemoryStreamSafe(this Stream stream, MemoryStream data, bool littleEndian)
        {
            var position = data.Position;
            data.Position = 0;

            uint myHash = FNV.InitialHash32;

            long left = data.Length;
            byte[] buffer = new byte[4096];
            while (left > 0)
            {
                int block = (int)(Math.Min(left, 4096));
                data.Read(buffer, 0, block);
                myHash = FNV.Hash32(buffer, 0, block);
                stream.Write(buffer, 0, block);
                left -= block;
            }

            stream.WriteValueU32(myHash, littleEndian);
            data.Position = position;
        }

        public static string ReadStringASCIIU32(this Stream stream)
        {
            uint length = stream.ReadValueU32();
            if (length > 0x3FF)
            {
                throw new InvalidOperationException();
            }
            return stream.ReadStringASCII(length);
        }
    }
}
