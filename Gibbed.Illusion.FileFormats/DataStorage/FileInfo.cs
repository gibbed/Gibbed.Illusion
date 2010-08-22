using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class FileInfo
    {
        public uint Unknown00;
        public uint Unknown04;
        public ushort Unknown08;
        public uint Unknown0A;
        public uint Unknown0E;
        public uint Unknown12;
        public uint Unknown16;

        public void Deserialize(Stream input, bool littleEndian)
        {
            this.Unknown00 = input.ReadValueU32(littleEndian);
            this.Unknown04 = input.ReadValueU32(littleEndian);
            this.Unknown08 = input.ReadValueU16(littleEndian);
            this.Unknown0A = input.ReadValueU32(littleEndian);
            this.Unknown0E = input.ReadValueU32(littleEndian);
            this.Unknown12 = input.ReadValueU32(littleEndian);
            this.Unknown16 = input.ReadValueU32(littleEndian);
        }
    }
}
