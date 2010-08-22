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
        public uint Unknown1C; // flags of some sort : see note 2
        public byte[] Unknown20;
        public uint FileCount;

        public void Deserialize(Stream input, bool littleEndian)
        {
            this.TypeTableOffset = input.ReadValueU32(littleEndian);
            this.BlockTableOffset = input.ReadValueU32(littleEndian);
            this.XmlOffset = input.ReadValueU32(littleEndian);
            this.Unknown0C = input.ReadValueU32(littleEndian);
            this.Unknown10 = input.ReadValueU32(littleEndian);
            this.Unknown14 = input.ReadValueU32(littleEndian);
            this.Unknown18 = input.ReadValueU32(littleEndian);
            this.Unknown1C = input.ReadValueU32(littleEndian);
            this.Unknown20 = new byte[16];
            input.Read(this.Unknown20, 0, this.Unknown20.Length);
            this.FileCount = input.ReadValueU32(littleEndian);
        }
    }
}
