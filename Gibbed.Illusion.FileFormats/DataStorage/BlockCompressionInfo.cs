using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class BlockCompressionInfo
    {
        public uint UncompressedSize;
        public uint Unknown04;
        public uint Unknown08;
        public uint Unknown0C;
        public uint CompressedSize;
        public uint Unknown14;
        public uint Unknown18;
        public uint Unknown1C;

        public void Deserialize(SdsStream input)
        {
            this.UncompressedSize = input.ReadValueU32();
            this.Unknown04 = input.ReadValueU32();
            this.Unknown08 = input.ReadValueU32();
            this.Unknown0C = input.ReadValueU32();
            this.CompressedSize = input.ReadValueU32();
            this.Unknown14 = input.ReadValueU32();
            this.Unknown18 = input.ReadValueU32();
            this.Unknown1C = input.ReadValueU32();
        }
    }
}
