using System;
using System.IO;
using System.Text;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats
{
    public static class StreamHelpers
    {
        static StreamHelpers()
        {
            Gibbed.Helpers.StreamHelpers.DefaultEncoding = Encoding.GetEncoding(1252);
        }

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

        public static string ReadStringU16(this Stream stream)
        {
            return stream.ReadStringU16(true);
        }

        public static string ReadStringU16(this Stream stream, bool littleEndian)
        {
            var length = stream.ReadValueU16(littleEndian);
            if (length > 0x3FF)
            {
                throw new InvalidOperationException();
            }
            return stream.ReadString(length);
        }

        public static string ReadStringU32(this Stream stream)
        {
            return stream.ReadStringU32(true);
        }

        public static string ReadStringU32(this Stream stream, bool littleEndian)
        {
            var length = stream.ReadValueU32(littleEndian);
            if (length > 0x3FF)
            {
                throw new InvalidOperationException();
            }
            return stream.ReadString(length);
        }

        public static void WriteStringU32(this Stream stream, string value)
        {
            stream.WriteStringU32(value, true);
        }

        public static void WriteStringU32(this Stream stream, string value, bool littleEndian)
        {
            stream.WriteValueS32(value.Length, littleEndian);
            stream.WriteString(value);
        }
    }
}
