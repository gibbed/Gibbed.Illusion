using System;
using System.Text;

namespace Gibbed.Illusion.FileFormats
{
	public static class FNV
	{
        public const uint InitialHash32 = 0x811C9DC5;

        public static uint Hash32(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Hash32(bytes, 0, bytes.Length);
        }

        public static uint Hash32(byte[] buffer, int offset, int count)
        {
            return Hash32(buffer, offset, count, InitialHash32);
        }

        public static uint Hash32(byte[] buffer, int offset, int count, uint hash)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("input");
            }

            for (int i = offset; i < offset + count; i++)
            {
                hash *= 0x1000193;
                hash ^= buffer[i];
            }

            return hash;
        }

        public const ulong InitialHash64 = 0xCBF29CE484222325;

        public static ulong Hash64(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Hash64(bytes, 0, bytes.Length);
        }

        public static ulong Hash64(byte[] buffer, int offset, int count)
        {
            return Hash64(buffer, offset, count, InitialHash64);
        }

        public static ulong Hash64(byte[] buffer, int offset, int count, ulong hash)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("input");
            }

            for (int i = offset; i < offset + count; i++)
            {
                hash *= 0x00000100000001B3;
                hash ^= buffer[i];
            }

            return hash;
        }
    }
}
