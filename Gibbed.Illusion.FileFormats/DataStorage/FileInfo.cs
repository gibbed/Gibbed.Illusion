using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void Deserialize(SdsStream input)
        {
            this.Unknown00 = input.ReadValueU32();
            this.Unknown04 = input.ReadValueU32();
            this.Unknown08 = input.ReadValueU16();
            this.Unknown0A = input.ReadValueU32();
            this.Unknown0E = input.ReadValueU32();
            this.Unknown12 = input.ReadValueU32();
            this.Unknown16 = input.ReadValueU32();
        }
    }
}
