using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.Illusion.FileFormats
{
    public static class TEA
    {
        /* /sds/tables/tables.sds
         * sum = 0xA62336C0
         * delta = 0x9D3119B6
         * rounds = 32 */
        public static void Decrypt(uint[] v, uint[] keys, uint sum, uint delta, uint rounds)
        {
            uint num_rounds = 32;

            uint v0 = v[0];
            uint v1 = v[1];

            for (uint i = 0; i < rounds; i++)
            {
                v1 -= ((v0 << 4) + keys[2]) ^ (v0 + sum) ^ ((v0 >> 5) + keys[3]);
                v0 -= ((v1 << 4) + keys[0]) ^ (v1 + sum) ^ ((v1 >> 5) + keys[1]);
                sum -= delta;
            }

            v[0] = v0;
            v[1] = v1;
        }

        public static void Decrypt(byte[] data, int offset, int count, uint[] keys, uint sum, uint delta, uint rounds)
        {
            for (int i = offset; i + 8 <= offset + count; i += 8)
            {
                UInt32[] v = new UInt32[2];
                v[0] = BitConverter.ToUInt32(data, i + 0);
                v[1] = BitConverter.ToUInt32(data, i + 4);

                Decrypt(v, keys, sum, delta, rounds);

                Array.Copy(BitConverter.GetBytes(v[0]), 0, data, i + 0, 4);
                Array.Copy(BitConverter.GetBytes(v[1]), 0, data, i + 4, 4);
            }
        }
    }
}
