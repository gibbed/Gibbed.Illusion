using System.IO;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class CompressedBlockHeader
    {
        public uint UncompressedSize;
        public uint Unknown04;
        public uint Unknown08;
        public uint Unknown0C;
        public uint CompressedSize;
        public uint Unknown14;
        public uint Unknown18;
        public uint Unknown1C;

        public void Deserialize(Stream input, Endian endian)
        {
            this.UncompressedSize = input.ReadValueU32(endian);
            this.Unknown04 = input.ReadValueU32(endian);
            this.Unknown08 = input.ReadValueU32(endian);
            this.Unknown0C = input.ReadValueU32(endian);
            this.CompressedSize = input.ReadValueU32(endian);
            this.Unknown14 = input.ReadValueU32(endian);
            this.Unknown18 = input.ReadValueU32(endian);
            this.Unknown1C = input.ReadValueU32(endian);
        }
    }
}
