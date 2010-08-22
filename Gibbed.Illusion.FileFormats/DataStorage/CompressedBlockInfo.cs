using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class CompressedBlockInfo
    {
        public uint UncompressedSize;
        public uint Unknown04;
        public uint Unknown08;
        public uint Unknown0C;
        public uint CompressedSize;
        public uint Unknown14;
        public uint Unknown18;
        public uint Unknown1C;

        public void Deserialize(Stream input, bool littleEndian)
        {
            this.UncompressedSize = input.ReadValueU32(littleEndian);
            this.Unknown04 = input.ReadValueU32(littleEndian);
            this.Unknown08 = input.ReadValueU32(littleEndian);
            this.Unknown0C = input.ReadValueU32(littleEndian);
            this.CompressedSize = input.ReadValueU32(littleEndian);
            this.Unknown14 = input.ReadValueU32(littleEndian);
            this.Unknown18 = input.ReadValueU32(littleEndian);
            this.Unknown1C = input.ReadValueU32(littleEndian);
        }
    }
}
