using System;

namespace Gibbed.Illusion.FileFormats
{
    public static class TEA
    {
        public class Setup
        {
            public uint Sum;
            public uint Delta;
            public uint Rounds;

            public Setup(uint sum, uint delta, uint rounds)
            {
                this.Sum = sum;
                this.Delta = delta;
                this.Rounds = rounds;
            }
        }

        public static class Mafia2
        {
            public static uint[] Keys = new uint[]
            {
                0x73766E46,
                0x6D454D5A,
                0x336A6D68,
                0x38425072,
            };

            public static Setup[] Setups = new Setup[]
            {
                new Setup(0x79FB0B01, 0x4B989BCD, 5),
                new Setup(0xA62336C0, 0x9D3119B6, 32),
            };
        }

        public static void Decrypt(uint[] v, uint[] keys, uint sum, uint delta, uint rounds)
        {
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
