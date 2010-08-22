using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class ArchiveInfo
    {
        public uint TypeTableOffset;
        public uint BlockTableOffset;
        public uint XmlOffset;
        public uint Unknown0C;
        public uint Unknown10;
        public uint Unknown14;
        public uint Unknown18;
        public uint Unknown1C; // Flags of some sort 0140C7FF
        public byte[] Unknown20;
        public uint FileCount; // ?? 0140C7F5

        public void Deserialize(SdsStream input)
        {
            this.TypeTableOffset = input.ReadValueU32();
            this.BlockTableOffset = input.ReadValueU32();
            this.XmlOffset = input.ReadValueU32();
            this.Unknown0C = input.ReadValueU32();
            this.Unknown10 = input.ReadValueU32();
            this.Unknown14 = input.ReadValueU32();
            this.Unknown18 = input.ReadValueU32();
            this.Unknown1C = input.ReadValueU32();
            this.Unknown20 = input.ReadBuffer(16);
            this.FileCount = input.ReadValueU32();
        }
    }
}
