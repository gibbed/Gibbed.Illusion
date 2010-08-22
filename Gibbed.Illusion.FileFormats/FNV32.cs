using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.Illusion.FileFormats
{
	public static class FNV32
	{
        private const uint InitialHash = 0x811C9DC5;

        public static uint Hash(byte[] buffer, int offset, int count)
        {
            return Hash(buffer, offset, count, InitialHash);
        }

        public static uint Hash(byte[] buffer, int offset, int count, uint hash)
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
    }
}
